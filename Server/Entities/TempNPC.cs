﻿using System;
using System.Drawing;
using CryBits.Entities;
using CryBits.Server.Logic;
using CryBits.Server.Network;
using static CryBits.Defaults;
using static CryBits.Utils;

namespace CryBits.Server.Entities
{
    internal class TempNPC : Character
    {
        // Dados básicos
        public readonly byte Index;
        public readonly NPC Data;
        public bool Alive;
        public Character Target;
        private int _spawnTimer;
        private int _attackTimer;

        private short Regeneration(byte vital)
        {
            // Cálcula o máximo de vital que o NPC possui
            switch ((Vitals)vital)
            {
                case Vitals.HP: return (short)(Data.Vital[vital] * 0.05 + Data.Attribute[(byte)Attributes.Vitality] * 0.3);
                case Vitals.MP: return (short)(Data.Vital[vital] * 0.05 + Data.Attribute[(byte)Attributes.Intelligence] * 0.1);
            }

            return 0;
        }

        // Construtor
        public TempNPC(byte index, TempMap map, NPC data)
        {
            Index = index;
            Map = map;
            Data = data;
        }

        /////////////
        // Funções //
        /////////////
        public void Logic()
        {
            ////////////////
            // Surgimento //
            ////////////////
            if (!Alive)
            {
                if (Environment.TickCount > _spawnTimer + Data.SpawnTime * 1000) Spawn();
                return;
            }

            byte targetX = 0, targetY = 0;
            bool[] canMove = new bool[(byte)Directions.Count];
            short distance;
            bool moved = false;
            bool move = false;

            /////////////////
            // Regeneração //
            /////////////////
            if (Environment.TickCount > Loop.TimerRegen + 5000)
                for (byte v = 0; v < (byte)Vitals.Count; v++)
                    if (Vital[v] < Data.Vital[v])
                    {
                        // Renera os vitais
                        Vital[v] += Regeneration(v);

                        // Impede que o valor passe do limite
                        if (Vital[v] > Data.Vital[v]) Vital[v] = Data.Vital[v];

                        // Envia os dados aos jogadores do mapa
                        Send.MapNPCVitals(this);
                    }

            //////////////////
            // Movimentação //
            //////////////////
            // Atacar ao ver
            if (Data.Behaviour == NPCs.AttackOnSight)
            {
                // Jogador
                if (Target == null)
                    foreach (var player in Account.List)
                    {
                        // Verifica se o jogador está jogando e no mesmo mapa que o NPC
                        if (!player.IsPlaying) continue;
                        if (player.Character.Map != Map) continue;

                        // Se o jogador estiver no alcance do NPC, ir atrás dele
                        distance = (short)Math.Sqrt(Math.Pow(X - player.Character.X, 2) +
                                                     Math.Pow(Y - player.Character.Y, 2));
                        if (distance <= Data.Sight)
                        {
                            Target = player.Character;

                            // Mensagem
                            if (!string.IsNullOrEmpty(Data.SayMsg))
                                Send.Message(player.Character, Data.Name + ": " + Data.SayMsg,
                                    Color.White);
                            break;
                        }
                    }

                // NPC
                if (Data.AttackNPC && Target == null)
                    for (byte npcIndex = 0; npcIndex < Map.NPC.Length; npcIndex++)
                    {
                        // Verifica se pode atacar
                        if (npcIndex == Index) continue;
                        if (!Map.NPC[npcIndex].Alive) continue;
                        if (Data.IsAllied(Map.NPC[npcIndex].Data)) continue;

                        // Se o NPC estiver no alcance do NPC, ir atrás dele
                        distance = (short)Math.Sqrt(Math.Pow(X - Map.NPC[npcIndex].X, 2) +
                                                     Math.Pow(Y - Map.NPC[npcIndex].Y, 2));
                        if (distance <= Data.Sight)
                        {
                            Target = Map.NPC[npcIndex];
                            break;
                        }
                    }
            }

            // Verifica se o alvo ainda está disponível
            if (Target != null)
                if (Target is Player && !((Player)Target).Account.IsPlaying || Target.Map != Map)
                    Target = null;
                else if (Target is TempNPC && !((TempNPC)Target).Alive)
                    Target = null;

            // Evita que ele se movimente sem sentido
            if (Target != null)
            {
                targetX = Target.X;
                targetY = Target.Y;

                // Verifica se o alvo saiu do alcance do NPC
                if (Data.Sight < Math.Sqrt(Math.Pow(X - targetX, 2) + Math.Pow(Y - targetY, 2)))
                    Target = null;
                else
                    move = true;
            }
            else
            {
                // Define o alvo a zona do NPC
                if (Map.Data.NPC[Index].Zone > 0)
                    if (Map.Data.Attribute[X, Y].Zone != Map.Data.NPC[Index].Zone)
                        for (byte x2 = 0; x2 < CryBits.Entities.Map.Width; x2++)
                            for (byte y2 = 0; y2 < CryBits.Entities.Map.Height; y2++)
                                if (Map.Data.Attribute[x2, y2].Zone == Map.Data.NPC[Index].Zone)
                                    if (!Map.Data.TileBlocked(x2, y2))
                                    {
                                        targetX = x2;
                                        targetY = y2;
                                        move = true;
                                        break;
                                    }
            }

            // Movimenta o NPC
            if (move)
            {
                // Verifica como o NPC pode se mover
                if (Vital[(byte)Vitals.HP] > Data.Vital[(byte)Vitals.HP] * (Data.FleeHealth / 100.0))
                {
                    // Para perto do alvo
                    canMove[(byte)Directions.Up] = Y > targetY;
                    canMove[(byte)Directions.Down] = Y < targetY;
                    canMove[(byte)Directions.Left] = X > targetX;
                    canMove[(byte)Directions.Right] = X < targetX;
                }
                else
                {
                    // Para longe do alvo
                    canMove[(byte)Directions.Up] = Y < targetY;
                    canMove[(byte)Directions.Down] = Y > targetY;
                    canMove[(byte)Directions.Left] = X < targetX;
                    canMove[(byte)Directions.Right] = X > targetX;
                }

                // Aleatoriza a forma que ele vai se movimentar até o alvo
                if (MyRandom.Next(0, 2) == 0)
                {
                    for (byte d = 0; d < (byte)Directions.Count; d++)
                        if (!moved && canMove[d] && Move((Directions)d))
                            moved = true;
                }
                else
                    for (short d = (byte)Directions.Count - 1; d >= 0; d--)
                        if (!moved && canMove[d] && Move((Directions)d))
                            moved = true;
            }

            // Move-se aleatoriamente
            if (Data.Behaviour == (byte)NPCs.Friendly || Target == null)
                if (MyRandom.Next(0, 3) == 0 && !moved)
                    if (Data.Movement == NPCMovements.MoveRandomly)
                        Move((Directions)MyRandom.Next(0, 4), 1, true);
                    else if (Data.Movement == NPCMovements.TurnRandomly)
                    {
                        Direction = (Directions)MyRandom.Next(0, 4);
                        Send.MapNPCDirection(this);
                    }

            ////////////
            // Ataque //
            ////////////
            Attack();
        }

        private void Spawn(byte x, byte y, Directions direction = 0)
        {
            // Faz o NPC surgir no mapa
            Alive = true;
            X = x;
            Y = y;
            Direction = direction;
            for (byte i = 0; i < (byte)Vitals.Count; i++) Vital[i] = Data.Vital[i];

            // Envia os dados aos jogadores
            if (Socket.Device != null) Send.MapNPC(Map.NPC[Index]);
        }

        public void Spawn()
        {
            // Antes verifica se tem algum local de aparecimento específico
            if (Map.Data.NPC[Index].Spawn)
            {
                Spawn(Map.Data.NPC[Index].X, Map.Data.NPC[Index].Y);
                return;
            }

            // Faz com que ele apareça em um local aleatório
            for (byte i = 0; i < 50; i++) // tenta 50 vezes com que ele apareça em um local aleatório
            {
                byte x = (byte)MyRandom.Next(0, CryBits.Entities.Map.Width - 1);
                byte y = (byte)MyRandom.Next(0, CryBits.Entities.Map.Height - 1);

                // Verifica se está dentro da zona
                if (Map.Data.NPC[Index].Zone > 0)
                    if (Map.Data.Attribute[x, y].Zone != Map.Data.NPC[Index].Zone)
                        continue;

                // Define os dados
                if (!Map.Data.TileBlocked(x, y))
                {
                    Spawn(x, y);
                    return;
                }
            }

            // Em último caso, tentar no primeiro lugar possível
            for (byte x2 = 0; x2 < CryBits.Entities.Map.Width; x2++)
                for (byte y2 = 0; y2 < CryBits.Entities.Map.Height; y2++)
                    if (!Map.Data.TileBlocked(x2, y2))
                    {
                        // Verifica se está dentro da zona
                        if (Map.Data.NPC[Index].Zone > 0)
                            if (Map.Data.Attribute[x2, y2].Zone != Map.Data.NPC[Index].Zone)
                                continue;

                        // Define os dados
                        Spawn(x2, y2);
                        return;
                    }
        }

        private bool Move(Directions direction, byte movement = 1, bool checkZone = false)
        {
            byte nextX = X, nextY = Y;

            // Define a direção do NPC
            Direction = direction;
            Send.MapNPCDirection(this);

            // Próximo azulejo
            NextTile(direction, ref nextX, ref nextY);

            // Próximo azulejo bloqueado ou fora do limite
            if (CryBits.Entities.Map.OutLimit(nextX, nextY)) return false;
            if (Map.TileBlocked(X, Y, direction)) return false;

            // Verifica se está dentro da zona
            if (checkZone)
                if (Map.Data.Attribute[nextX, nextY].Zone != Map.Data.NPC[Index].Zone)
                    return false;

            // Movimenta o NPC
            X = nextX;
            Y = nextY;
            Send.MapNPCMovement(this, movement);
            return true;
        }

        private void Attack()
        {
            byte nextX = X, nextY = Y;
            NextTile(Direction, ref nextX, ref nextY);

            // Apenas se necessário
            if (!Alive) return;
            if (Environment.TickCount < _attackTimer + AttackSpeed) return;
            if (Map.TileBlocked(X, Y, Direction, false)) return;

            // Verifica se o jogador está na frente do NPC
            if (Target is Player)
                AttackPlayer(Map.HasPlayer(nextX, nextY));
            // Verifica se o NPC alvo está na frente do NPC
            else if (Target is TempNPC)
                AttackNPC(Map.HasNPC(nextX, nextY));
        }

        private void AttackPlayer(Player victim)
        {
            // Verifica se a vítima pode ser atacada
            if (victim == null) return;
            if (victim.GettingMap) return;

            // Tempo de ataque 
            _attackTimer = Environment.TickCount;

            // Cálculo de dano
            short attackDamage = (short)(Data.Attribute[(byte)Attributes.Strength] - victim.PlayerDefense);

            // Dano não fatal
            if (attackDamage > 0)
            {
                // Demonstra o ataque aos outros jogadores
                Send.MapNPCAttack(this, victim.Name, Targets.Player);

                if (attackDamage < victim.Vital[(byte)Vitals.HP])
                {
                    victim.Vital[(byte)Vitals.HP] -= attackDamage;
                    Send.PlayerVitals(victim);
                }
                // FATALITY
                else
                {
                    // Reseta o alvo do NPC
                    Target = null;

                    // Mata o jogador
                    victim.Died();
                }
            }
            // Demonstra o ataque aos outros jogadores
            else
                Send.MapNPCAttack(this);
        }

        private void AttackNPC(TempNPC victim)
        {
            // Verifica se a vítima pode ser atacada
            if (victim == null) return;
            if (!victim.Alive) return;

            // Tempo de ataque 
            _attackTimer = Environment.TickCount;

            // Define o alvo do NPC
            victim.Target = this;

            // Cálculo de dano
            short attackDamage = (short)(Data.Attribute[(byte)Attributes.Strength] - victim.Data.Attribute[(byte)Attributes.Resistance]);

            // Dano não fatal
            if (attackDamage > 0)
            {
                // Demonstra o ataque aos outros jogadores
                Send.MapNPCAttack(this, victim.Index.ToString(), Targets.NPC);

                if (attackDamage < victim.Vital[(byte)Vitals.HP])
                {
                    victim.Vital[(byte)Vitals.HP] -= attackDamage;
                    Send.MapNPCVitals(victim);
                }
                // FATALITY
                else
                {
                    // Reseta o alvo do NPC
                    Target = null;

                    // Mata o NPC
                    victim.Died();
                }
            }
            // Demonstra o ataque aos outros jogadores
            else
                Send.MapNPCAttack(this);
        }

        public void Died()
        {
            // Solta os itens
            for (byte i = 0; i < Data.Drop.Count; i++)
                if (Data.Drop[i].Item != null)
                    if (MyRandom.Next(1, 99) <= Data.Drop[i].Chance)
                        // Solta o item
                        Map.Item.Add(new MapItems(Data.Drop[i].Item, Data.Drop[i].Amount, X, Y));

            // Envia os dados dos itens no chão para o mapa
            Send.MapItems(Map);

            // Reseta os dados do NPC 
            _spawnTimer = Environment.TickCount;
            Target = null;
            Alive = false;
            Send.MapNPCDied(this);
        }
    }
}
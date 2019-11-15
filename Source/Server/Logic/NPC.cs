﻿using System;
using System.IO;
using Lidgren.Network;

class NPC
{
    public enum Behaviour
    {
        Friendly,
        AttackOnSight,
        AttackWhenAttacked
    }

    public static short[] MaxVital(byte Index, short Map)
    {
        return Lists.NPC[Lists.Map[Map].NPC[Index].Index].Vital;
    }

    public static short Regeneration(short Map_Num, byte Index, byte Vital)
    {
        Lists.Structures.NPCs Data = Lists.NPC[Lists.Map[Map_Num].Temp_NPC[Index].Index];

        // Cálcula o máximo de vital que o NPC possui
        switch ((Game.Vitals)Vital)
        {
            case Game.Vitals.HP: return (short)(Data.Vital[Vital] * 0.05 + Data.Attribute[(byte)Game.Attributes.Vitality] * 0.3);
            case Game.Vitals.MP: return (short)(Data.Vital[Vital] * 0.05 + Data.Attribute[(byte)Game.Attributes.Intelligence] * 0.1);
        }

        return 0;
    }

    public static void Logic(short Map_Num)
    {
        // Lógica dos NPCs
        for (byte i = 1; i <= Lists.Map[Map_Num].Temp_NPC.GetUpperBound(0); i++)
        {
            Lists.Structures.Map_NPCs Data = Lists.Map[Map_Num].Temp_NPC[i];
            Lists.Structures.NPCs NPC_Data = Lists.NPC[Lists.Map[Map_Num].NPC[i].Index];

            //////////////////
            // Aparecimento //
            //////////////////
            if (Data.Index == 0)
            {
                if (Environment.TickCount > Data.Spawn_Timer + (NPC_Data.SpawnTime * 1000)) Spawn(i, Map_Num);
            }
            else
            {
                byte TargetX = 0, TargetY = 0;
                bool[] CanMove = new bool[(byte)Game.Directions.Amount];
                short Distance_X, Distance_Y;
                bool Moved = false;
                bool Move = false;

                /////////////////
                // Regeneração //
                /////////////////
                if (Environment.TickCount > Loop.Timer_NPC_Regen + 5000)
                    for (byte v = 0; v <= (byte)Game.Vitals.Amount - 1; v++)
                        if (Data.Vital[v] < NPC_Data.Vital[v])
                        {
                            // Renera os vitais
                            Lists.Map[Map_Num].Temp_NPC[i].Vital[v] += Regeneration(Map_Num, i, v);

                            // Impede que o valor passe do limite
                            if (Lists.Map[Map_Num].Temp_NPC[i].Vital[v] > NPC_Data.Vital[v])
                                Lists.Map[Map_Num].Temp_NPC[i].Vital[v] = NPC_Data.Vital[v];

                            // Envia os dados aos jogadores do mapa
                            Send.Map_NPC_Vitals(Map_Num, i);
                        }

                ///////////////
                // Movimento //
                ///////////////
                // Atacar ao ver
                if (Lists.Map[Map_Num].Temp_NPC[i].Target_Index == 0 && NPC_Data.Behaviour == (byte)Behaviour.AttackOnSight)
                    for (byte p = 1; p <= Game.HigherIndex; p++)
                    {
                        // Verifica se o jogador está jogando e no mesmo mapa que o NPC
                        if (!Player.IsPlaying(p)) continue;
                        if (Player.Character(p).Map != Map_Num) continue;

                        // Distância entre o NPC e o jogador
                        Distance_X = (short)(Data.X - Player.Character(p).X);
                        Distance_Y = (short)(Data.Y - Player.Character(p).Y);
                        if (Distance_X < 0) Distance_X *= -1;
                        if (Distance_Y < 0) Distance_Y *= -1;

                        // Se estiver no alcance, ir atrás do jogador
                        if (Distance_X <= NPC_Data.Sight && Distance_Y <= NPC_Data.Sight)
                        {
                            Lists.Map[Map_Num].Temp_NPC[i].Target_Type = (byte)Game.Target.Player;
                            Lists.Map[Map_Num].Temp_NPC[i].Target_Index = p;
                            Data = Lists.Map[Map_Num].Temp_NPC[i];
                        }
                    }

                if (Data.Target_Type == (byte)Game.Target.Player)
                {
                    // Verifica se o jogador ainda está disponível
                    if (!Player.IsPlaying(Data.Target_Index) || Player.Character(Data.Target_Index).Map != Map_Num)
                    {
                        Lists.Map[Map_Num].Temp_NPC[i].Target_Type = 0;
                        Lists.Map[Map_Num].Temp_NPC[i].Target_Index = 0;
                        Data = Lists.Map[Map_Num].Temp_NPC[i];
                    }

                    // Posição do alvo
                    TargetX = Player.Character(Lists.Map[Map_Num].Temp_NPC[i].Target_Index).X;
                    TargetY = Player.Character(Lists.Map[Map_Num].Temp_NPC[i].Target_Index).Y;
                }

                // Distância entre o NPC e o alvo
                Distance_X = (short)(Data.X - TargetX);
                Distance_Y = (short)(Data.Y - TargetY);
                if (Distance_X < 0) Distance_X *= -1;
                if (Distance_Y < 0) Distance_Y *= -1;

                // Verifica se o alvo saiu do alcance
                if (Distance_X > NPC_Data.Sight || Distance_Y > NPC_Data.Sight)
                {
                    Lists.Map[Map_Num].Temp_NPC[i].Target_Type = 0;
                    Lists.Map[Map_Num].Temp_NPC[i].Target_Index = 0;
                    Data = Lists.Map[Map_Num].Temp_NPC[i];
                }

                // Evita que ele se movimente sem sentido
                if (Data.Target_Index > 0)
                    Move = true;
                else
                {
                    // Define o alvo até a zona do NPC
                    if (Lists.Map[Map_Num].NPC[i].Zone > 0)
                        if (Lists.Map[Map_Num].Tile[Data.X, Data.Y].Zone != Lists.Map[Map_Num].NPC[i].Zone)
                            for (byte x2 = 0; x2 <= Lists.Map[Map_Num].Width; x2++)
                                for (byte y2 = 0; y2 <= Lists.Map[Map_Num].Height; y2++)
                                    if (Lists.Map[Map_Num].Tile[x2, y2].Zone == Lists.Map[Map_Num].NPC[i].Zone)
                                        if (!Map.Tile_Blocked(Map_Num, x2, y2))
                                        {
                                            TargetX = x2;
                                            TargetY = y2;
                                            Move = true;
                                            break;
                                        }
                }

                // Movimenta o NPC até mais perto do alvo
                if (Move)
                {
                    // Verifica como pode se mover até o alvo
                    if (Data.Y > TargetY) CanMove[(byte)Game.Directions.Up] = true;
                    if (Data.Y < TargetY) CanMove[(byte)Game.Directions.Down] = true;
                    if (Data.X > TargetX) CanMove[(byte)Game.Directions.Left] = true;
                    if (Data.X < TargetX) CanMove[(byte)Game.Directions.Right] = true;

                    // Aleatoriza a forma que ele vai se movimentar até o alvo
                    if (Game.Random.Next(0, 2) == 0)
                    {
                        for (byte d = 0; d <= (byte)Game.Directions.Amount - 1; d++)
                            if (!Moved && CanMove[d] && NPC.Move(Map_Num, i, (Game.Directions)d))
                                Moved = true;
                    }
                    else
                        for (short d = (byte)Game.Directions.Amount - 1; d >= 0; d--)
                            if (!Moved && CanMove[d] && NPC.Move(Map_Num, i, (Game.Directions)d))
                                Moved = true;
                }

                // Move-se aleatoriamente
                if (NPC_Data.Behaviour == (byte)Behaviour.Friendly || Data.Target_Index == 0)
                    if (Game.Random.Next(0, 3) == 0 && !Moved)
                        NPC.Move(Map_Num, i, (Game.Directions)Game.Random.Next(0, 4), 1, true);
            }

            ////////////
            // Ataque //
            ////////////
            short Next_X = Data.X, Next_Y = Data.Y;
            Map.NextTile(Data.Direction, ref Next_X, ref Next_Y);
            if (Data.Target_Type == (byte)Game.Target.Player)
            {
                // Verifica se o jogador está na frente do NPC
                if (Map.HasPlayer(Map_Num, Next_X, Next_Y) == Data.Target_Index) Attack_Player(Map_Num, i, Data.Target_Index);
            }
        }
    }

    public static void Spawn(byte Index, short Map_Num)
    {
        byte x, y;

        // Antes verifica se tem algum local de aparecimento específico
        if (Lists.Map[Map_Num].NPC[Index].Spawn)
        {
            Spawn(Index, Map_Num, Lists.Map[Map_Num].NPC[Index].X, Lists.Map[Map_Num].NPC[Index].Y);
            return;
        }

        // Faz com que ele apareça em um local aleatório
        for (byte i = 0; i <= 50; i++) // tenta 50 vezes com que ele apareça em um local aleatório
        {
            x = (byte)Game.Random.Next(0, Lists.Map[Map_Num].Width);
            y = (byte)Game.Random.Next(0, Lists.Map[Map_Num].Height);

            // Verifica se está dentro da zona
            if (Lists.Map[Map_Num].NPC[Index].Zone > 0)
                if (Lists.Map[Map_Num].Tile[x, y].Zone != Lists.Map[Map_Num].NPC[Index].Zone)
                    continue;

            // Define os dados
            if (!global::Map.Tile_Blocked(Map_Num, x, y))
            {
                Spawn(Index, Map_Num, x, y);
                return;
            }
        }

        // Em último caso, tentar no primeiro lugar possível
        for (byte x2 = 0; x2 <= Lists.Map[Map_Num].Width; x2++)
            for (byte y2 = 0; y2 <= Lists.Map[Map_Num].Height; y2++)
                if (!global::Map.Tile_Blocked(Map_Num, x2, y2))
                {
                    // Verifica se está dentro da zona
                    if (Lists.Map[Map_Num].NPC[Index].Zone > 0)
                        if (Lists.Map[Map_Num].Tile[x2, y2].Zone != Lists.Map[Map_Num].NPC[Index].Zone)
                            continue;

                    // Define os dados
                    Spawn(Index, Map_Num, x2, y2);
                    return;
                }
    }

    public static void Spawn(byte Index, short Map, byte x, byte y, Game.Directions Direction = 0)
    {
        Lists.Structures.NPCs Data = Lists.NPC[Lists.Map[Map].NPC[Index].Index];
        short[] s = Data.Vital;

        // Define os dados
        Lists.Map[Map].Temp_NPC[Index].Index = Lists.Map[Map].NPC[Index].Index;
        Lists.Map[Map].Temp_NPC[Index].X = x;
        Lists.Map[Map].Temp_NPC[Index].Y = y;
        Lists.Map[Map].Temp_NPC[Index].Direction = Direction;
        Lists.Map[Map].Temp_NPC[Index].Vital = new short[(byte)Game.Vitals.Amount];
        for (byte i = 0; i <= (byte)Game.Vitals.Amount - 1; i++) Lists.Map[Map].Temp_NPC[Index].Vital[i] = Data.Vital[i];

        // Envia os dados aos jogadores
        if (Socket.Device != null) Send.Map_NPC(Map, Index);
    }

    public static bool Move(short Map_Num, byte Index, Game.Directions Direction, byte Movement = 1, bool CountZone = false)
    {
        Lists.Structures.Map_NPCs Data = Lists.Map[Map_Num].Temp_NPC[Index];
        byte x = Data.X, y = Data.Y;
        short Next_X = x, Next_Y = y;

        // Define a direção do NPC
        Lists.Map[Map_Num].Temp_NPC[Index].Direction = Direction;
        Send.Map_NPC_Direction(Map_Num, Index);

        // Próximo azulejo
        Map.NextTile(Direction, ref Next_X, ref Next_Y);

        // Próximo azulejo bloqueado ou fora do limite
        if (Map.OutLimit(Map_Num, Next_X, Next_Y)) return false;
        if (Map.Tile_Blocked(Map_Num, x, y, Direction)) return false;

        // Verifica se está dentro da zona
        if (CountZone)
            if (Lists.Map[Map_Num].Tile[Next_X, Next_Y].Zone != Lists.Map[Map_Num].NPC[Index].Zone)
                return false;

        // Movimenta o NPC
        Lists.Map[Map_Num].Temp_NPC[Index].X = (byte)Next_X;
        Lists.Map[Map_Num].Temp_NPC[Index].Y = (byte)Next_Y;
        Send.Map_NPC_Movement(Map_Num, Index, Movement);
        return true;
    }

    public static void Attack_Player(short Map_Num, byte Index, byte Victim)
    {
        Lists.Structures.Map_NPCs Data = Lists.Map[Map_Num].Temp_NPC[Index];
        short x = Data.X, y = Data.Y;

        // Define o azujelo a frente do NPC
        Map.NextTile(Data.Direction, ref x, ref y);

        // Verifica se a vítima pode ser atacada
        if (Data.Index == 0) return;
        if (Environment.TickCount < Data.Attack_Timer + 750) return;
        if (!Player.IsPlaying(Victim)) return;
        if (Lists.TempPlayer[Victim].GettingMap) return;
        if (Map_Num != Player.Character(Victim).Map) return;
        if (Player.Character(Victim).X != x || Player.Character(Victim).Y != y) return;
        if (Map.Tile_Blocked(Map_Num, Data.X, Data.Y, Data.Direction, false)) return;

        // Tempo de ataque 
        Lists.Map[Map_Num].Temp_NPC[Index].Attack_Timer = Environment.TickCount;

        // Demonstra o ataque aos outros jogadores
        Send.Map_NPC_Attack(Map_Num, Index, Victim, (byte)Game.Target.Player);

        // Cálculo de dano
        short Damage = (short)(Lists.NPC[Data.Index].Attribute[(byte)Game.Attributes.Strength] - Player.Character(Victim).Player_Defense);

        // Dano não fatal
        if (Damage > 0)
            if (Damage < Player.Character(Victim).Vital[(byte)Game.Vitals.HP])
            {
                Player.Character(Victim).Vital[(byte)Game.Vitals.HP] -= Damage;
                Send.Player_Vitals(Victim);
            }
            // FATALITY
            else
            {
                // Reseta o alvo do NPC
                Lists.Map[Map_Num].Temp_NPC[Index].Target_Type = 0;
                Lists.Map[Map_Num].Temp_NPC[Index].Target_Index = 0;

                // Mata o jogador
                Player.Died(Victim);
            }
    }

    public static void Died(short Map_Num, byte Index)
    {
        Lists.Structures.NPCs NPC = Lists.NPC[Lists.Map[Map_Num].Temp_NPC[Index].Index];

        // Solta os itens
        for (byte i = 0; i <= Game.Max_NPC_Drop - 1; i++)
            if (NPC.Drop[i].Item_Num > 0)
                if (Game.Random.Next(NPC.Drop[i].Chance, 101) == 100)
                {
                    // Dados do item
                    Lists.Structures.Map_Items Item = new Lists.Structures.Map_Items();
                    Item.Index = NPC.Drop[i].Item_Num;
                    Item.Amount = NPC.Drop[i].Amount;
                    Item.X = Lists.Map[Map_Num].Temp_NPC[Index].X;
                    Item.Y = Lists.Map[Map_Num].Temp_NPC[Index].Y;

                    // Solta
                    Lists.Map[Map_Num].Temp_Item.Add(Item);
                }

        // Envia os dados dos itens no chão para o mapa
        Send.Map_Items(Map_Num);

        // Reseta os dados do NPC 
        Lists.Map[Map_Num].Temp_NPC[Index].Vital[(byte)Game.Vitals.HP] = 0;
        Lists.Map[Map_Num].Temp_NPC[Index].Spawn_Timer = Environment.TickCount;
        Lists.Map[Map_Num].Temp_NPC[Index].Index = 0;
        Lists.Map[Map_Num].Temp_NPC[Index].Target_Type = 0;
        Lists.Map[Map_Num].Temp_NPC[Index].Target_Index = 0;
        Send.Map_NPC_Died(Map_Num, Index);
    }
}

partial class Read
{
    public static void NPCs()
    {
        Lists.NPC = new Lists.Structures.NPCs[Lists.Server_Data.Num_NPCs + 1];

        // Lê os dados
        for (byte i = 1; i <= Lists.NPC.GetUpperBound(0); i++)
            NPC(i);
    }

    public static void NPC(byte Index)
    {
        // Cria um sistema binário para a manipulação dos dados
        FileInfo File = new FileInfo(Directories.NPCs.FullName + Index + Directories.Format);
        BinaryReader Data = new BinaryReader(File.OpenRead());

        // Redimensiona os valores necessários 
        Lists.NPC[Index].Vital = new short[(byte)Game.Vitals.Amount];
        Lists.NPC[Index].Attribute = new short[(byte)Game.Attributes.Amount];
        Lists.NPC[Index].Drop = new Lists.Structures.NPC_Drop[Game.Max_NPC_Drop];

        // Lê os dados
        Lists.NPC[Index].Name = Data.ReadString();
        Lists.NPC[Index].Texture = Data.ReadInt16();
        Lists.NPC[Index].Behaviour = Data.ReadByte();
        Lists.NPC[Index].SpawnTime = Data.ReadByte();
        Lists.NPC[Index].Sight = Data.ReadByte();
        Lists.NPC[Index].Experience = Data.ReadByte();
        for (byte i = 0; i <= (byte)Game.Vitals.Amount - 1; i++) Lists.NPC[Index].Vital[i] = Data.ReadInt16();
        for (byte i = 0; i <= (byte)Game.Attributes.Amount - 1; i++) Lists.NPC[Index].Attribute[i] = Data.ReadInt16();
        for (byte i = 0; i <= Game.Max_NPC_Drop - 1; i++)
        {
            Lists.NPC[Index].Drop[i].Item_Num = Data.ReadInt16();
            Lists.NPC[Index].Drop[i].Amount = Data.ReadInt16();
            Lists.NPC[Index].Drop[i].Chance = Data.ReadByte();
        }

        // Fecha o sistema
        Data.Dispose();
    }
}

partial class Send
{
    public static void NPCs(byte Index)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.NPCs);
        Data.Write((byte)Lists.NPC.GetUpperBound(0));
        for (byte i = 1; i <= Lists.NPC.GetUpperBound(0); i++)
        {
            // Geral
            Data.Write(Lists.NPC[i].Name);
            Data.Write(Lists.NPC[i].Texture);
            Data.Write(Lists.NPC[i].Behaviour);
            for (byte n = 0; n <= (byte)Game.Vitals.Amount - 1; n++) Data.Write(Lists.NPC[i].Vital[n]);
        }
        ToPlayer(Index, Data);
    }

    public static void Map_NPCs(byte Index, short Map)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPCs);
        Data.Write((short)Lists.Map[Map].Temp_NPC.GetUpperBound(0));
        for (byte i = 1; i <= Lists.Map[Map].Temp_NPC.GetUpperBound(0); i++)
        {
            Data.Write(Lists.Map[Map].Temp_NPC[i].Index);
            Data.Write(Lists.Map[Map].Temp_NPC[i].X);
            Data.Write(Lists.Map[Map].Temp_NPC[i].Y);
            Data.Write((byte)Lists.Map[Map].Temp_NPC[i].Direction);
            for (byte n = 0; n <= (byte)Game.Vitals.Amount - 1; n++) Data.Write(Lists.Map[Map].Temp_NPC[i].Vital[n]);
        }
        ToPlayer(Index, Data);
    }

    public static void Map_NPC(short Map, byte Index)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPC);
        Data.Write(Index);
        Data.Write(Lists.Map[Map].Temp_NPC[Index].Index);
        Data.Write(Lists.Map[Map].Temp_NPC[Index].X);
        Data.Write(Lists.Map[Map].Temp_NPC[Index].Y);
        Data.Write((byte)Lists.Map[Map].Temp_NPC[Index].Direction);
        for (byte n = 0; n <= (byte)Game.Vitals.Amount - 1; n++) Data.Write(Lists.Map[Map].Temp_NPC[Index].Vital[n]);
        ToMap(Map, Data);
    }

    public static void Map_NPC_Movement(short Map, byte Index, byte Movimento)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPC_Movement);
        Data.Write(Index);
        Data.Write(Lists.Map[Map].Temp_NPC[Index].X);
        Data.Write(Lists.Map[Map].Temp_NPC[Index].Y);
        Data.Write((byte)Lists.Map[Map].Temp_NPC[Index].Direction);
        Data.Write(Movimento);
        ToMap(Map, Data);
    }

    public static void Map_NPC_Direction(short Map, byte Index)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPC_Direction);
        Data.Write(Index);
        Data.Write((byte)Lists.Map[Map].Temp_NPC[Index].Direction);
        ToMap(Map, Data);
    }

    public static void Map_NPC_Vitals(short Map, byte Index)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPC_Vitals);
        Data.Write(Index);
        for (byte n = 0; n <= (byte)Game.Vitals.Amount - 1; n++) Data.Write(Lists.Map[Map].Temp_NPC[Index].Vital[n]);
        ToMap(Map, Data);
    }

    public static void Map_NPC_Attack(short Map, byte Index, byte Victim, byte Victim_Type)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPC_Attack);
        Data.Write(Index);
        Data.Write(Victim);
        Data.Write(Victim_Type);
        ToMap(Map, Data);
    }

    public static void Map_NPC_Died(short Map, byte Index)
    {
        NetOutgoingMessage Data = Socket.Device.CreateMessage();

        // Envia os dados
        Data.Write((byte)Packets.Map_NPC_Died);
        Data.Write(Index);
        ToMap(Map, Data);
    }
}
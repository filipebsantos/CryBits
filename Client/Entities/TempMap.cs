﻿using System;
using System.Collections.Generic;
using System.Drawing;
using CryBits.Client.Media.Audio;
using CryBits.Entities;
using static CryBits.Utils;
using static CryBits.Defaults;
using Graphics = CryBits.Client.Media.Graphics;

namespace CryBits.Client.Entities
{
    internal class TempMap
    {
        // Mapa atual
        public static TempMap Current;

        // Lista de dados
        public static Dictionary<Guid, TempMap> List;
        public MapWeatherParticle[] Weather;

        // Dados gerais
        public readonly Map Data;
        public TempNPC[] NPC;
        public MapItems[] Item = new MapItems[0];
        public List<MapBlood> Blood = new List<MapBlood>();

        // Fumaças
        public int FogX;
        public int FogY;
        private int _fogXTimer;
        private int _fogYTimer;

        // Clima
        public byte Lightning;
        private int _snowTimer;
        private int _lightningTimer;

        // Sangue
        private int _bloodTimer;

        public TempMap(Map data)
        {
            Data = data;
        }

        private bool HasNPC(byte x, byte y)
        {
            // Verifica se há algum npc na cordenada
            for (byte i = 0; i < NPC.Length; i++)
                if (NPC[i].Data != null)
                    if ((NPC[i].X, NPC[i].Y) == (x, y))
                        return true;

            return false;
        }

        private bool HasPlayer(short x, short y)
        {
            // Verifica se há algum Jogador na cordenada
            for (byte i = 0; i < Player.List.Count; i++)
                if ((Player.List[i].X, Player.List[i].Y, Player.List[i].Map) == (x, y, this))
                    return true;

            return false;
        }

        public bool Tile_Blocked(byte x, byte y, Directions direction)
        {
            byte nextX = x, nextY = y;

            // Próximo azulejo
            NextTile(direction, ref nextX, ref nextY);

            // Verifica se está indo para uma ligação
            if (OutOfLimit(nextX, nextY)) return Data.Link[(byte)direction] == null;

            // Verifica se o azulejo está bloqueado
            if (Data.Attribute[nextX, nextY].Type == (byte)LayerAttributes.Block) return true;
            if (Data.Attribute[nextX, nextY].Block[(byte)ReverseDirection(direction)]) return true;
            if (Data.Attribute[x, y].Block[(byte)direction]) return true;
            if (HasPlayer(nextX, nextY) || HasNPC(nextX, nextY)) return true;
            return false;
        }

        // Verifica se as coordenas estão no limite do mapa
        public bool OutOfLimit(int x, int y) => x >= Map.Width || y >= Map.Height || x < 0 || y < 0;

        public void Logic()
        {
            // Toda a lógica do mapa
            UpdateFog();
            UpdateWeather();

            // Retira os sangues do chão depois de um determinado tempo
            if (_bloodTimer < Environment.TickCount)
                for (byte i = 0; i < Blood.Count; i++)
                {
                    Blood[i].Opacity -= 1;
                    if (Blood[i].Opacity == 0) Blood.RemoveAt(i);
                    _bloodTimer = Environment.TickCount + 100;
                }
        }

        private void UpdateFog()
        {
            // Faz a movimentação
            UpdateFogX();
            UpdateFogY();
        }

        private void UpdateFogX()
        {
            Size size = Graphics.Size(Graphics.TexFog[Data.Fog.Texture]);
            int speedX = Data.Fog.SpeedX;

            // Apenas se necessário
            if (_fogXTimer >= Environment.TickCount) return;
            if (speedX == 0) return;

            // Movimento para trás
            if (speedX < 0)
            {
                FogX -= 1;
                if (FogX < -size.Width) FogX = 0;
            }
            // Movimento para frente
            else
            {
                FogX += 1;
                if (FogX > size.Width) FogX = 0;
            }

            // Contagem
            if (speedX < 0) speedX *= -1;
            _fogXTimer = Environment.TickCount + 50 - speedX;
        }

        private void UpdateFogY()
        {
            Size size = Graphics.Size(Graphics.TexFog[Data.Fog.Texture]);
            int speedY = Data.Fog.SpeedY;

            // Apenas se necessário
            if (_fogYTimer >= Environment.TickCount) return;
            if (speedY == 0) return;

            // Movimento para trás
            if (speedY < 0)
            {
                FogY -= 1;
                if (FogY < -size.Height) FogY = 0;
            }
            // Movimento para frente
            else
            {
                FogY += 1;
                if (FogY > size.Height) FogY = 0;
            }

            // Contagem
            if (speedY < 0) speedY *= -1;
            _fogYTimer = Environment.TickCount + 50 - speedY;
        }

        private void UpdateWeather()
        {
            bool stop = false, move;
            byte thunderFirst = (byte)Sounds.Thunder1;
            byte thunderLast = (byte)Sounds.Thunder4;

            // Somente se necessário
            if (Data.Weather.Type == 0) return;

            // Contagem da neve
            if (_snowTimer < Environment.TickCount)
            {
                move = true;
                _snowTimer = Environment.TickCount + 35;
            }
            else
                move = false;

            // Contagem dos relâmpagos
            if (Lightning > 0)
                if (_lightningTimer < Environment.TickCount)
                {
                    Lightning -= 10;
                    _lightningTimer = Environment.TickCount + 25;
                }

            // Adiciona uma nova partícula
            for (short i = 1; i < Weather.Length; i++)
                if (!Weather[i].Visible)
                {
                    if (MyRandom.Next(0, MaxWeatherIntensity - Data.Weather.Intensity) == 0)
                    {
                        if (!stop)
                        {
                            // Cria a partícula
                            Weather[i].Visible = true;

                            // Cria a partícula de acordo com o seu tipo
                            switch (Data.Weather.Type)
                            {
                                case Weathers.Thundering:
                                case Weathers.Raining:
                                    Weather[i].SetRain();
                                    break;
                                case Weathers.Snowing:
                                    Weather[i].SetSnow();
                                    break;
                            }
                        }
                    }

                    stop = true;
                }
                else
                {
                    // Movimenta a partícula de acordo com o seu tipo
                    switch (Data.Weather.Type)
                    {
                        case Weathers.Thundering:
                        case Weathers.Raining:
                            Weather[i].MoveRain();
                            break;
                        case Weathers.Snowing:
                            Weather[i].MoveSnow(move);
                            break;
                    }

                    // Reseta a partícula
                    if (Weather[i].X > ScreenWidth || Weather[i].Y > ScreenHeight) Weather[i] = new MapWeatherParticle();
                }

            // Trovoadas
            if (Data.Weather.Type == Weathers.Thundering)
                if (MyRandom.Next(0, MaxWeatherIntensity * 10 - Data.Weather.Intensity * 2) == 0)
                {
                    // Som do trovão
                    int thunder = MyRandom.Next(thunderFirst, thunderLast);
                    Sound.Play((Sounds)thunder);

                    // Relâmpago
                    if (thunder < 6) Lightning = 190;
                }
        }

        public void UpdateWeatherType()
        {
            // Para todos os sons
            Sound.Stop_All();

            // Redimensiona a lista
            switch (Data.Weather.Type)
            {
                case Weathers.Thundering:
                case Weathers.Raining:
                    // Reproduz o som chuva
                    Sound.Play(Sounds.Rain, true);

                    // Redimensiona a estrutura
                    Weather = new MapWeatherParticle[MaxRain + 1];
                    break;
                case Weathers.Snowing:
                    Weather = new MapWeatherParticle[MaxSnow + 1];
                    break;
            }
        }
    }

    internal class MapItems
    {
        public Item Item;
        public byte X;
        public byte Y;
    }

    internal class MapBlood
    {
        // Dados
        public byte TextureNum;
        public short X;
        public short Y;
        public byte Opacity;

        // Construtor
        public MapBlood(byte textureNum, short x, short y, byte opacity)
        {
            TextureNum = textureNum;
            X = x;
            Y = y;
            Opacity = opacity;
        }
    }

    internal class MapWeatherParticle
    {
        public bool Visible;
        public int X;
        public int Y;
        public int Speed;
        public int Start;
        public bool Back;

        public void MoveRain()
        {
            // Movimenta a partícula
            X += Speed;
            Y += Speed;
        }

        public void SetRain()
        {
            // Define a velocidade e a posição da partícula
            Speed = MyRandom.Next(8, 13);

            if (MyRandom.Next(2) == 0)
            {
                X = -32;
                Y = MyRandom.Next(-32, ScreenHeight);
            }
            else
            {
                X = MyRandom.Next(-32, ScreenWidth);
                Y = -32;
            }
        }

        public void SetSnow()
        {
            // Define a velocidade e a posição da partícula
            Speed = MyRandom.Next(1, 3);
            Y = -32;
            X = MyRandom.Next(-32, ScreenWidth);
            Start = X;
            Back = MyRandom.Next(2) != 0;
        }

        public  void MoveSnow( bool xAxis = true)
        {
            int difference = MyRandom.Next(0, SnowMovement / 3);
            int x1 = Start + SnowMovement + difference;
            int x2 = Start - SnowMovement - difference;

            // Faz com que a partícula volte
            if (x1 <= X)
                Back = true;
            else if (x2 >= X)
                Back = false;

            // Movimenta a partícula
            Y += Speed;

            if (xAxis)
                if (Back)
                    X -= 1;
                else
                    X += 1;
        }
    }
}
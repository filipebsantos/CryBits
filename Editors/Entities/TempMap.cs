﻿using CryBits.Editors.Forms;
using CryBits.Entities;
using System;
using System.Drawing;
using SFML.Audio;
using static CryBits.Defaults;
using static CryBits.Utils;
using Graphics = CryBits.Editors.Media.Graphics;
using Sound = CryBits.Editors.Media.Audio.Sound;

namespace CryBits.Editors.Entities
{
    internal static class TempMap
    {        
        // Contadores
        private static int _fogXTimer;
        private static int _fogYTimer;
        private static int _snowTimer;
        private static int _thunderingTimer;

        // Fumaças
        public static int FogX;
        public static int FogY;

        // Clima
        public static MapWeatherParticle[] Weather;
        public static byte Lightning;

        public static void UpdateWeatherType()
        {
            // Redimensiona a lista
            if (EditorMaps.Form != null)
                switch (EditorMaps.Form.Selected.Weather.Type)
                {
                    case Weathers.Thundering:
                    case Weathers.Raining: Weather = new MapWeatherParticle[Map.MaxRainParticles + 1]; break;
                    case Weathers.Snowing: Weather = new MapWeatherParticle[Map.MaxSnowParticles + 1]; break;
                }
        }


        public static void UpdateFog()
        {
            // Faz a movimentação
            if (EditorMaps.Form != null && EditorMaps.Form.Visible)
            {
                UpdateFogX();
                UpdateFogY();
            }
        }

        private static void UpdateFogX()
        {
            Size textureSize = Graphics.Size(Graphics.TexFog[EditorMaps.Form.Selected.Fog.Texture]);
            int speed = EditorMaps.Form.Selected.Fog.SpeedX;

            // Apenas se necessário
            if (_fogXTimer >= Environment.TickCount) return;
            if (speed == 0) return;

            // Movimento para trás
            if (speed < 0)
            {
                FogX -= 1;
                if (FogX < -textureSize.Width) FogX = 0;
            }
            // Movimento para frente
            else
            {
                FogX += 1;
                if (FogX > textureSize.Width) FogX = 0;
            }

            // Contagem
            if (speed < 0) speed *= -1;
            _fogXTimer = Environment.TickCount + 50 - speed;
        }

        private static void UpdateFogY()
        {
            Size textureSize = Graphics.Size(Graphics.TexFog[EditorMaps.Form.Selected.Fog.Texture]);
            int speed = EditorMaps.Form.Selected.Fog.SpeedY;

            // Apenas se necessário
            if (_fogYTimer >= Environment.TickCount) return;
            if (speed == 0) return;

            // Movimento para trás
            if (speed < 0)
            {
                FogY -= 1;
                if (FogY < -textureSize.Height) FogY = 0;
            }
            // Movimento para frente
            else
            {
                FogY += 1;
                if (FogY > textureSize.Height) FogY = 0;
            }

            // Contagem
            if (speed < 0) speed *= -1;
            _fogYTimer = Environment.TickCount + 50 - speed;
        }

        public static void UpdateWeather()
        {
            bool stop = false, move;

            // Somente se necessário
            if (EditorMaps.Form == null || !EditorMaps.Form.Visible || EditorMaps.Form.Selected.Weather.Type == 0 || !EditorMaps.Form.butVisualization.Checked)
            {
                if (Sound.List != null)
                    if (Sound.List[(byte)Sounds.Rain].Status == SoundStatus.Playing) Sound.StopAll();
                return;
            }

            // Clima do mapa
            MapWeather weather = EditorMaps.Form.Selected.Weather;

            // Reproduz o som chuva
            if (weather.Type == Weathers.Raining || weather.Type == Weathers.Thundering)
            {
                if (Sound.List[(byte)Sounds.Rain].Status != SoundStatus.Playing)
                    Sound.Play(Sounds.Rain);
            }
            else
              if (Sound.List[(byte)Sounds.Rain].Status == SoundStatus.Playing) Sound.StopAll();

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
                if (_thunderingTimer < Environment.TickCount)
                {
                    Lightning -= 10;
                    _thunderingTimer = Environment.TickCount + 25;
                }

            // Adiciona uma nova partícula
            for (int i = 1; i <= Weather.GetUpperBound(0); i++)
                if (!Weather[i].Visible)
                {
                    if (MyRandom.Next(0, Map.MaxWeatherIntensity - weather.Intensity) == 0)
                    {
                        if (!stop)
                        {
                            // Cria a partícula
                            Weather[i].Visible = true;

                            // Cria a partícula de acordo com o seu tipo
                            switch (weather.Type)
                            {
                                case Weathers.Thundering:
                                case Weathers.Raining: SetRain(i); break;
                                case Weathers.Snowing: SetSnow(i); break;
                            }
                        }
                    }

                    stop = true;
                }
                else
                {
                    // Movimenta a partícula de acordo com o seu tipo
                    switch (weather.Type)
                    {
                        case Weathers.Thundering:
                        case Weathers.Raining: MoveRain(i); break;
                        case Weathers.Snowing: SnowMove(i, move); break;
                    }

                    // Reseta a partícula
                    if (Weather[i].X > Map.Width * Grid || Weather[i].Y > Map.Height * Grid)
                        Weather[i] = new MapWeatherParticle();
                }

            // Trovoadas
            if (weather.Type == Weathers.Thundering)
                if (MyRandom.Next(0, Map.MaxWeatherIntensity * 10 - weather.Intensity * 2) == 0)
                {
                    // Som do trovão
                    int thunder = MyRandom.Next((byte)Sounds.Thunder1, (byte)Sounds.Thunder4);
                    Sound.Play((Sounds)thunder);

                    // Relâmpago
                    if (thunder < 6) Lightning = 190;
                }
        }

        private static void SetRain(int i)
        {
            // Define a velocidade e a posição da partícula
            Weather[i].Speed = MyRandom.Next(8, 13);

            if (MyRandom.Next(2) == 0)
            {
                Weather[i].X = -32;
                Weather[i].Y = MyRandom.Next(-32, EditorMaps.Form.picMap.Height);
            }
            else
            {
                Weather[i].X = MyRandom.Next(-32, EditorMaps.Form.picMap.Width);
                Weather[i].Y = -32;
            }
        }

        private static void MoveRain(int i)
        {
            // Movimenta a partícula
            Weather[i].X += Weather[i].Speed;
            Weather[i].Y += Weather[i].Speed;
        }

        private static void SetSnow(int i)
        {
            // Define a velocidade e a posição da partícula
            Weather[i].Speed = MyRandom.Next(1, 3);
            Weather[i].Y = -32;
            Weather[i].X = MyRandom.Next(-32, EditorMaps.Form.picMap.Width);
            Weather[i].Start = Weather[i].X;
            Weather[i].Back = MyRandom.Next(2) != 0;
        }

        private static void SnowMove(int i, bool move = true)
        {
            int difference = MyRandom.Next(0, Map.SnowMovement / 3);
            int x1 = Weather[i].Start + Map.SnowMovement + difference;
            int x2 = Weather[i].Start - Map.SnowMovement - difference;

            // Faz com que a partícula volte
            if (x1 <= Weather[i].X)
                Weather[i].Back = true;
            else if (x2 >= Weather[i].X)
                Weather[i].Back = false;

            // Movimenta a partícula
            Weather[i].Y += Weather[i].Speed;

            if (move)
                if (Weather[i].Back)
                    Weather[i].X -= 1;
                else
                    Weather[i].X += 1;
        }
    }
}

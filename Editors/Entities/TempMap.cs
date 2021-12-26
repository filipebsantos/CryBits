﻿using CryBits.Editors.Forms;
using CryBits.Editors.Library;
using CryBits.Entities;

namespace CryBits.Editors.Entities
{
    internal static class TempMap
    {
        // Fumaças
        public static int FogX;
        public static int FogY;

        // Clima
        public static byte Lightning;

        public static void UpdateWeather()
        {
            // Redimensiona a lista
            if (EditorMaps.Form != null)
                switch (EditorMaps.Form.Selected.Weather.Type)
                {
                    case Weathers.Thundering:
                    case Weathers.Raining: Lists.Weather = new MapWeatherParticle[Map.MaxRainParticles + 1]; break;
                    case Weathers.Snowing: Lists.Weather = new MapWeatherParticle[Map.MaxSnowParticles + 1]; break;
                }
        }
    }
}

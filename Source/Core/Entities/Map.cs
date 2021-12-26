﻿using System;
using System.Collections.Generic;

namespace CryBits.Entities
{
    [Serializable]
    public class Map : Entity
    {
        // Lista de dados
        public static Dictionary<Guid, Map> List = new Dictionary<Guid, Map>();

        // Obtém o dado, caso ele não existir retorna nulo
        public static Map Get(Guid ID) => List.ContainsKey(ID) ? List[ID] : null;

        // Tamanho dos mapas
        public const byte Width = 25;
        public const byte Height = 19;

        // Dados
        public short Revision;
        public byte Moral;
        public Map_Layer[] Layer = Array.Empty<Map_Layer>();
        public Map_Attribute[,] Attribute = new Map_Attribute[Width, Height];
        public byte Panorama;
        public byte Music;
        public int Color = -1;
        public Map_Weather Weather = new Map_Weather();
        public Map_Fog Fog = new Map_Fog();
        public Map_NPC[] NPC = Array.Empty<Map_NPC>();
        public Map_Light[] Light = Array.Empty<Map_Light>();
        public byte Lighting = 100;
        public Map[] Link = new Map[(byte)Directions.Count];

        // Construtor
        public Map(Guid ID) : base(ID)
        {
            for (byte x = 0; x < Width; x++)
                for (byte y = 0; y < Height; y++)
                    Attribute[x, y] = new Map_Attribute();
        }

        // Verifica se as coordenas estão no limite do mapa
        public bool OutLimit(byte X, byte Y) => X >= Width || Y >= Height || X < 0 || Y < 0;

        public bool Tile_Blocked(byte X, byte Y)
        {
            // Verifica se o azulejo está bloqueado
            if (OutLimit(X, Y)) return true;
            if (Attribute[X, Y].Type == (byte)TileAttributes.Block) return true;
            return false;
        }
    }

    [Serializable]
    public class Map_Attribute
    {
        public byte Type;
        public string Data_1;
        public short Data_2;
        public short Data_3;
        public short Data_4;
        public byte Zone;
        public bool[] Block = new bool[(byte)Directions.Count];
    }

    [Serializable]
    public class Map_Layer
    {
        public string Name;
        public byte Type;
        public Map_Tile_Data[,] Tile = new Map_Tile_Data[Map.Width, Map.Height];

        public Map_Layer()
        {
            for (byte x = 0; x < Map.Width; x++)
                for (byte y = 0; y < Map.Height; y++)
                    Tile[x, y] = new Map_Tile_Data();
        }
    }

    [Serializable]
    public class Map_NPC
    {
        public NPC NPC;
        public byte Zone;
        public bool Spawn;
        public byte X;
        public byte Y;
    }

    [Serializable]
    public class Map_Tile_Data
    {
        public byte X;
        public byte Y;
        public byte Tile;
        public bool Auto;
    }

    [Serializable]
    public class Map_Light
    {
        public byte X;
        public byte Y;
        public byte Width;
        public byte Height;
    }

    [Serializable]
    public class Map_Weather
    {
        public byte Type;
        public byte Intensity;
    }

    [Serializable]
    public class Map_Fog
    {
        public byte Texture;
        public sbyte Speed_X;
        public sbyte Speed_Y;
        public byte Alpha = 255;
    }
}
﻿using System;
using System.Collections.Generic;
using CryBits.Client.Logic;
using static CryBits.Client.Logic.Utils;

namespace CryBits.Client.Entities
{
    class TempMap
    {
        // Lista de dados
        public static Dictionary<Guid, TempMap> List;
        public static MapWeatherParticle[] Weather;

        // Dados gerais
        public Map Data;
        public TempNPC[] NPC;
        public MapItems[] Item = new MapItems[0];
        public List<MapBlood> Blood = new List<MapBlood>();

        public TempMap(Map data)
        {
            this.Data = data;
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
            if (Mapper.OutOfLimit(nextX, nextY)) return Data.Link[(byte)direction] == 0;

            // Verifica se o azulejo está bloqueado
            if (Data.Tile[nextX, nextY].Attribute == (byte)LayerAttributes.Block) return true;
            if (Data.Tile[nextX, nextY].Block[(byte)ReverseDirection(direction)]) return true;
            if (Data.Tile[x, y].Block[(byte)direction]) return true;
            if (HasPlayer(nextX, nextY) || HasNPC(nextX, nextY)) return true;
            return false;
        }
    }

    class MapItems
    {
        public Item Item;
        public byte X;
        public byte Y;
    }

    class MapBlood
    {
        // Dados
        public byte Texture_Num;
        public short X;
        public short Y;
        public byte Opacity;

        // Construtor
        public MapBlood(byte textureNum, short x, short y, byte opacity)
        {
            this.Texture_Num = textureNum;
            this.X = x;
            this.Y = y;
            this.Opacity = opacity;
        }
    }

    class MapWeatherParticle
    {
        public bool Visible;
        public int X;
        public int Y;
        public int Speed;
        public int Start;
        public bool Back;
    }
}
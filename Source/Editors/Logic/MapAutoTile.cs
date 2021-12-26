﻿using Objects;
using System.Drawing;
using static Utils;

class MapAutotile
{
    // Formas de adicionar o mini azulejo
    public enum AddMode
    {
        None,
        Inside,
        Exterior,
        Horizontal,
        Vertical,
        Fill
    }

    public static void Update(Map Map)
    {
        // Atualiza os azulejos necessários
        for (byte x = 0; x < Map.Width; x++)
            for (byte y = 0; y < Map.Height; y++)
                for (byte c = 0; c < Map.Layer.Count; c++)
                    if (Map.Layer[c].Tile[x, y].Auto)
                        // Faz os cálculos para a autocriação
                        Calculate(Map, x, y, c);
    }

    public static void Update(Map Map, int x, int y, byte Layer_Num)
    {
        // Atualiza os azulejos necessários
        for (int x2 = x - 2; x2 < x + 2; x2++)
            for (int y2 = y - 2; y2 < y + 2; y2++)
                if (x2 >= 0 && x2 < Map.Width && y2 >= 0 && y2 < Map.Height)
                    // Faz os cálculos para a autocriação
                    Calculate(Map, (byte)x2, (byte)y2, Layer_Num);
    }

    private static void Set(Map Map, byte x, byte y, byte Layer_Num, byte Part, string Index)
    {
        Point Position = new Point(0);

        // Posições exatas dos mini azulejos (16x16)
        switch (Index)
        {
            // Quinas
            case "a": Position = new Point(32, 0); break;
            case "b": Position = new Point(48, 0); break;
            case "c": Position = new Point(32, 16); break;
            case "d": Position = new Point(48, 16); break;

            // Noroeste
            case "e": Position = new Point(0, 32); break;
            case "f": Position = new Point(16, 32); break;
            case "g": Position = new Point(0, 48); break;
            case "h": Position = new Point(16, 48); break;

            // Nordeste
            case "i": Position = new Point(32, 32); break;
            case "j": Position = new Point(48, 32); break;
            case "k": Position = new Point(32, 48); break;
            case "l": Position = new Point(48, 48); break;

            // Sudoeste
            case "m": Position = new Point(0, 64); break;
            case "n": Position = new Point(16, 64); break;
            case "o": Position = new Point(0, 80); break;
            case "p": Position = new Point(16, 80); break;

            // Sudeste
            case "q": Position = new Point(32, 64); break;
            case "r": Position = new Point(48, 64); break;
            case "s": Position = new Point(32, 80); break;
            case "t": Position = new Point(48, 80); break;
        }

        // Define a posição do mini azulejo
        Map_Tile_Data Data = Map.Layer[Layer_Num].Tile[x, y];
        Map.Layer[Layer_Num].Tile[x, y].Mini[Part].X = Data.X * Grid + Position.X;
        Map.Layer[Layer_Num].Tile[x, y].Mini[Part].Y = Data.Y * Grid + Position.Y;
    }

    private static bool Check(Map Map, int X1, int Y1, int X2, int Y2, byte Layer_Num)
    {
        Map_Tile_Data Data1, Data2;

        // Somente se necessário
        if (X1 < 0 || X1 >= Map.Width || Y1 < 0 || Y1 >= Map.Height) return true;
        if (X2 < 0 || X2 >= Map.Width || Y2 < 0 || Y2 >= Map.Height) return true;

        // Dados
        Data1 = Map.Layer[Layer_Num].Tile[X1, Y1];
        Data2 = Map.Layer[Layer_Num].Tile[X2, Y2];

        // Verifica se são os mesmo azulejos
        if (!Data2.Auto) return false;
        if (Data1.Tile != Data2.Tile) return false;
        if (Data1.X != Data2.X) return false;
        if (Data1.Y != Data2.Y) return false;

        // Não há nada de errado
        return true;
    }

    private static void Calculate(Map Map, byte x, byte y, byte Layer_Num)
    {
        // Calcula as quatros partes do azulejo
        Calculate_NW(Map, x, y, Layer_Num);
        Calculate_NE(Map, x, y, Layer_Num);
        Calculate_SW(Map, x, y, Layer_Num);
        Calculate_SE(Map, x, y, Layer_Num);
    }

    private static void Calculate_NW(Map Map, byte x, byte y, byte Layer_Num)
    {
        bool[] Tile = new bool[4];
        AddMode Mode = AddMode.None;

        // Verifica se existe algo para modificar nos azulejos em volta (Norte, Oeste, Noroeste)
        if (Check(Map, x, y, x - 1, y - 1, Layer_Num)) Tile[1] = true;
        if (Check(Map, x, y, x, y - 1, Layer_Num)) Tile[2] = true;
        if (Check(Map, x, y, x - 1, y, Layer_Num)) Tile[3] = true;

        // Forma que será adicionado o mini azulejo
        if (!Tile[2] && !Tile[3]) Mode = AddMode.Inside;
        if (!Tile[2] && Tile[3]) Mode = AddMode.Horizontal;
        if (Tile[2] && !Tile[3]) Mode = AddMode.Vertical;
        if (!Tile[1] && Tile[2] && Tile[3]) Mode = AddMode.Exterior;
        if (Tile[1] && Tile[2] && Tile[3]) Mode = AddMode.Fill;

        // Define o mini azulejo
        switch (Mode)
        {
            case AddMode.Inside: Set(Map, x, y, Layer_Num, 0, "e"); break;
            case AddMode.Exterior: Set(Map, x, y, Layer_Num, 0, "a"); break;
            case AddMode.Horizontal: Set(Map, x, y, Layer_Num, 0, "i"); break;
            case AddMode.Vertical: Set(Map, x, y, Layer_Num, 0, "m"); break;
            case AddMode.Fill: Set(Map, x, y, Layer_Num, 0, "q"); break;
        }
    }

    private static void Calculate_NE(Map Map, byte x, byte y, byte Layer_Num)
    {
        bool[] Tile = new bool[4];
        AddMode Mode = AddMode.None;

        // Verifica se existe algo para modificar nos azulejos em volta (Norte, Oeste, Noroeste)
        if (Check(Map, x, y, x, y - 1, Layer_Num)) Tile[1] = true;
        if (Check(Map, x, y, x + 1, y - 1, Layer_Num)) Tile[2] = true;
        if (Check(Map, x, y, x + 1, y, Layer_Num)) Tile[3] = true;

        // Forma que será adicionado o mini azulejo
        if (!Tile[1] && !Tile[3]) Mode = AddMode.Inside;
        if (!Tile[1] && Tile[3]) Mode = AddMode.Horizontal;
        if (Tile[1] && !Tile[3]) Mode = AddMode.Vertical;
        if (Tile[1] && !Tile[2] && Tile[3]) Mode = AddMode.Exterior;
        if (Tile[1] && Tile[2] && Tile[3]) Mode = AddMode.Fill;

        // Define o mini azulejo
        switch (Mode)
        {
            case AddMode.Inside: Set(Map, x, y, Layer_Num, 1, "j"); break;
            case AddMode.Exterior: Set(Map, x, y, Layer_Num, 1, "b"); break;
            case AddMode.Horizontal: Set(Map, x, y, Layer_Num, 1, "f"); break;
            case AddMode.Vertical: Set(Map, x, y, Layer_Num, 1, "r"); break;
            case AddMode.Fill: Set(Map, x, y, Layer_Num, 1, "n"); break;
        }
    }

    private static void Calculate_SW(Map Map, byte x, byte y, byte Layer_Num)
    {
        bool[] Tile = new bool[4];
        AddMode Mode = AddMode.None;

        // Verifica se existe algo para modificar nos azulejos em volta (Sul, Oeste, Sudoeste)
        if (Check(Map, x, y, x - 1, y, Layer_Num)) Tile[1] = true;
        if (Check(Map, x, y, x - 1, y + 1, Layer_Num)) Tile[2] = true;
        if (Check(Map, x, y, x, y + 1, Layer_Num)) Tile[3] = true;

        // Forma que será adicionado o mini azulejo
        if (!Tile[1] && !Tile[3]) Mode = AddMode.Inside;
        if (Tile[1] && !Tile[3]) Mode = AddMode.Horizontal;
        if (!Tile[1] && Tile[3]) Mode = AddMode.Vertical;
        if (Tile[1] && !Tile[2] && Tile[3]) Mode = AddMode.Exterior;
        if (Tile[1] && Tile[2] && Tile[3]) Mode = AddMode.Fill;

        // Define o mini azulejo
        switch (Mode)
        {
            case AddMode.Inside: Set(Map, x, y, Layer_Num, 2, "o"); break;
            case AddMode.Exterior: Set(Map, x, y, Layer_Num, 2, "c"); break;
            case AddMode.Horizontal: Set(Map, x, y, Layer_Num, 2, "s"); break;
            case AddMode.Vertical: Set(Map, x, y, Layer_Num, 2, "g"); break;
            case AddMode.Fill: Set(Map, x, y, Layer_Num, 2, "k"); break;
        }
    }

    private static void Calculate_SE(Map Map, byte x, byte y, byte Layer_Num)
    {
        bool[] Tile = new bool[4];
        AddMode Mode = AddMode.None;

        // Verifica se existe algo para modificar nos azulejos em volta (Sul, Oeste, Sudeste)
        if (Check(Map, x, y, x, y + 1, Layer_Num)) Tile[1] = true;
        if (Check(Map, x, y, x + 1, y + 1, Layer_Num)) Tile[2] = true;
        if (Check(Map, x, y, x + 1, y, Layer_Num)) Tile[3] = true;

        // Forma que será adicionado o mini azulejo
        if (!Tile[1] && !Tile[3]) Mode = AddMode.Inside;
        if (!Tile[1] && Tile[3]) Mode = AddMode.Horizontal;
        if (Tile[1] && !Tile[3]) Mode = AddMode.Vertical;
        if (Tile[1] && !Tile[2] && Tile[3]) Mode = AddMode.Exterior;
        if (Tile[1] && Tile[2] && Tile[3]) Mode = AddMode.Fill;

        // Define o mini azulejo
        switch (Mode)
        {
            case AddMode.Inside: Set(Map, x, y, Layer_Num, 3, "t"); break;
            case AddMode.Exterior: Set(Map, x, y, Layer_Num, 3, "d"); break;
            case AddMode.Horizontal: Set(Map, x, y, Layer_Num, 3, "p"); break;
            case AddMode.Vertical: Set(Map, x, y, Layer_Num, 3, "l"); break;
            case AddMode.Fill: Set(Map, x, y, Layer_Num, 3, "h"); break;
        }
    }
}
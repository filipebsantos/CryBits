﻿using System;
using System.Drawing;

class Globals
{
    // Dimensão das grades 
    public const byte Grid = 32;
    public static Size Grid_Size = new Size(Grid, Grid);

    // Medida de calculo do atraso do jogo
    public static short FPS;

    // Limitações dos mapas
    public const byte Map_Width = 25;
    public const byte Map_Height = 19;
    public const byte Num_Zones = 20;

    // Fumaças
    public static int Fog_X;
    public static int Fog_Y;

    // Clima
    public const byte Max_Rain_Particles = 100;
    public const short Max_Snow_Particles = 635;
    public const byte Max_Weather_Intensity = 10;
    public const byte Snow_Movement = 10;
    public static byte Lightning;

    // Números aleAmountatórios
    public static Random GameRandom = new Random();

    public enum Tools_Types
    {
        Button,
        Panel,
        CheckBox,
        TextBox,
        Count
    }

    public enum Tile_Attributes
    {
        None,
        Block,
        Warp,
        Item,
        Count
    }

    public enum Layers
    {
        Ground,
        Fringe,
        Count
    }

    public enum Vitals
    {
        HP,
        MP,
        Count
    }

    public enum Attributes
    {
        Strength,
        Resistance,
        Intelligence,
        Agility,
        Vitality,
        Count
    }

    public enum Map_Morals
    {
        Pacific,
        Dangerous
    }

    public enum Weathers
    {
        Normal,
        Raining,
        Thundering,
        Snowing
    }

    public enum Directions
    {
        Up,
        Down,
        Left,
        Right,
        Count
    }

    public enum Tiles_Mode
    {
        Normal,
        Automatic,
        Automatic_Animated
    }

    public enum Items
    {
        None,
        Equipment,
        Potion
    }

    public enum Equipments
    {
        Weapon,
        Armor,
        Helmet,
        Shield,
        Amulet,
        Count
    }

    public enum Windows
    {
        Menu,
        Game
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Count
    }

    public enum BindOn
    {
        None,
        Pickup,
        Equip,
        Count
    }

    public enum NPC_Behaviour
    {
        Friendly,
        AttackOnSight,
        AttackWhenAttacked,
        ShopKeeper
    }

    public enum NPC_Movements
    {
        MoveRandomly,
        TurnRandomly,
        StandStill
    }

    public static void Weather_Update()
    {
        // Redimensiona a lista
        if (Editor_Maps.Form != null)
            switch (Editor_Maps.Form.Selected.Weather.Type)
            {
                case Weathers.Thundering:
                case Weathers.Raining: Lists.Weather = new Lists.Structures.Weather[Max_Rain_Particles + 1]; break;
                case Weathers.Snowing: Lists.Weather = new Lists.Structures.Weather[Max_Snow_Particles + 1]; break;
            }
    }

    public static Point Block_Position(byte Direction)
    {
        // Retorna a posição de cada seta do bloqueio direcional
        switch ((Directions)Direction)
        {
            case Directions.Up: return new Point(Grid / 2 - 4, 0);
            case Directions.Down: return new Point(Grid / 2 - 4, Grid - 9);
            case Directions.Left: return new Point(0, Grid / 2 - 4);
            case Directions.Right: return new Point(Grid - 9, Grid / 2 - 4);
            default: return new Point(0);
        }
    }

    // Tamanho da grade com o zoom
    public static byte Grid_Zoom => (byte)(Grid / Editor_Maps.Form.Zoom());
    public static Point Zoom(int X, int Y) => new Point(X * Grid_Zoom, Y * Grid_Zoom);
}

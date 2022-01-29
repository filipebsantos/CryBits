﻿using System.Drawing;
using CryBits.Client.Framework.Constants;
using SFML.Graphics;

namespace CryBits.Client.Framework.Graphics;

public static class Textures
{
    // Texturas
    public static readonly List<Texture> Characters = LoadTextures(Directories.TexCharacters.FullName);
    public static readonly List<Texture> Tiles = LoadTextures(Directories.TexTiles.FullName);
    public static readonly List<Texture> Faces = LoadTextures(Directories.TexFaces.FullName);
    public static readonly List<Texture> Panels = LoadTextures(Directories.TexPanels.FullName);
    public static readonly List<Texture> Buttons = LoadTextures(Directories.TexButtons.FullName);
    public static readonly List<Texture> Panoramas = LoadTextures(Directories.TexPanoramas.FullName);
    public static readonly List<Texture> Fogs = LoadTextures(Directories.TexFogs.FullName);
    public static readonly List<Texture> Items = LoadTextures(Directories.TexItems.FullName);
    public static readonly Texture CheckBox = new(Directories.TexCheckBox.FullName + Format);
    public static readonly Texture TextBox = new(Directories.TexTextBox.FullName + Format);
    public static readonly Texture Weather = new(Directories.TexWeather.FullName + Format);
    public static readonly Texture Blank = new(Directories.TexBlank.FullName + Format);
    public static readonly Texture Shadow = new(Directories.TexShadow.FullName + Format);
    public static readonly Texture Bars = new(Directories.TexBars.FullName + Format);
    public static readonly Texture BarsPanel = new(Directories.TexBarsPanel.FullName + Format);
    public static readonly Texture Equipments = new(Directories.TexEquipments.FullName + Format);
    public static readonly Texture Blood = new(Directories.TexBlood.FullName + Format);
    public static readonly Texture PartyBars = new(Directories.TexPartyBars.FullName + Format);
    public static readonly Texture Directions = new(Directories.TexDirections.FullName + Format);
    public static readonly Texture Transparent = new(Directories.TexTransparent.FullName + Format);
    public static readonly Texture Grid = new(Directories.TexGrid.FullName + Format);

    // Formato das texturas
    private const string Format = ".png";

    private static List<Texture> LoadTextures(string directory)
    {
        short i = 1;
        var tempTex = new List<Texture> { null };

        // Carrega todas do diretório e as adiciona a lista
        while (File.Exists(directory + i + Format))
            tempTex.Add(new Texture(directory + i++ + Format));

        // Retorna o cache da textura
        return tempTex;
    }

    // Retorna com o tamanho da textura

    public static Size ToSize(this Texture texture) => new ((int)texture.Size.X, (int)texture.Size.Y);
}
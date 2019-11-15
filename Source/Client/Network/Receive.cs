﻿using Lidgren.Network;
using System;
using System.Drawing;
using System.Windows.Forms;

partial class Receive
{
    // Pacotes do servidor
    public enum Packets
    {
        Alert,
        Connect,
        CreateCharacter,
        Join,
        Classes,
        Characters,
        JoinGame,
        HigherIndex,
        Player_Data,
        Player_Position,
        Player_Vitals,
        Player_Leave,
        Player_Attack,
        Player_Move,
        Player_Direction,
        Player_Experience,
        Player_Inventory,
        Player_Equipments,
        Player_Hotbar,
        JoinMap,
        Map_Revision,
        Map,
        Latency,
        Message,
        NPCs,
        Map_NPCs,
        Map_NPC,
        Map_NPC_Movement,
        Map_NPC_Direction,
        Map_NPC_Vitals,
        Map_NPC_Attack,
        Map_NPC_Died,
        Items,
        Map_Items
    }

    public static void Handle(NetIncomingMessage Data)
    {
        // Manuseia os dados recebidos
        switch ((Packets)Data.ReadByte())
        {
            case Packets.Alert: Alert(Data); break;
            case Packets.Connect: Connect(Data); break;
            case Packets.Join: Join(Data); break;
            case Packets.CreateCharacter: CreateCharacter(Data); break;
            case Packets.JoinGame: JoinGame(Data); break;
            case Packets.Classes: Classes(Data); break;
            case Packets.Characters: Characters(Data); break;
            case Packets.HigherIndex: HigherIndex(Data); break;
            case Packets.Player_Data: Player_Data(Data); break;
            case Packets.Player_Position: Player_Position(Data); break;
            case Packets.Player_Vitals: Player_Vitals(Data); break;
            case Packets.Player_Move: Player_Move(Data); break;
            case Packets.Player_Leave: Player_Leave(Data); break;
            case Packets.Player_Direction: Player_Direction(Data); break;
            case Packets.Player_Attack: Player_Attack(Data); break;
            case Packets.Player_Experience: Player_Experience(Data); break;
            case Packets.Player_Inventory: Player_Inventory(Data); break;
            case Packets.Player_Equipments: Player_Equipments(Data); break;
            case Packets.Player_Hotbar: Player_Hotbar(Data); break;
            case Packets.Map_Revision: Map_Revision(Data); break;
            case Packets.Map: Map(Data); break;
            case Packets.JoinMap: JoinMap(Data); break;
            case Packets.Latency: Latency(Data); break;
            case Packets.Message: Message(Data); break;
            case Packets.NPCs: NPCs(Data); break;
            case Packets.Map_NPCs: Map_NPCs(Data); break;
            case Packets.Map_NPC: Map_NPC(Data); break;
            case Packets.Map_NPC_Movement: Map_NPC_Movement(Data); break;
            case Packets.Map_NPC_Direction: Map_NPC_Direction(Data); break;
            case Packets.Map_NPC_Vitals: Map_NPC_Vitals(Data); break;
            case Packets.Map_NPC_Attack: Map_NPC_Attack(Data); break;
            case Packets.Map_NPC_Died: Map_NPC_Died(Data); break;
            case Packets.Items: Items(Data); break;
            case Packets.Map_Items: Map_Items(Data); break;
        }
    }

    private static void Alert(NetIncomingMessage Data)
    {
        // Mostra a mensagem
        MessageBox.Show(Data.ReadString());
    }

    private static void Connect(NetIncomingMessage Data)
    {
        // Reseta os valores
        Game.SelectCharacter = 1;

        // Abre o painel de seleção de personagens
        Panels.Menu_Close();
        Panels.Find("SelecionarPersonagem").General.Visible = true;
    }

    private static void Join(NetIncomingMessage Data)
    {
        // Definir os valores que são enviados do servidor
        Player.MyIndex = Data.ReadByte();
        Player.HigherIndex = Data.ReadByte();

        // Limpa a estrutura dos jogadores
        Lists.Player = new Lists.Structures.Player[Data.ReadByte() + 1];

        for (byte i = 1; i <= Lists.Player.GetUpperBound(0); i++)
            Clear.Player(i);
    }

    private static void CreateCharacter(NetIncomingMessage Data)
    {
        // Reseta os valores
        TextBoxes.Find("CriarPersonagem_Nome").Text = string.Empty;
        CheckBoxes.Find("GêneroMasculino").State = true;
        CheckBoxes.Find("GêneroFeminino").State = false;
        Game.CreateCharacter_Class = 1;

        // Abre o painel de criação de personagem
        Panels.Menu_Close();
        Panels.Find("CriarPersonagem").General.Visible = true;
    }

    private static void Classes(NetIncomingMessage Data)
    {
        int Amount = Data.ReadByte();

        // Recebe os dados das classes
        Lists.Class = new Lists.Structures.Class[Amount + 1];

        for (byte i = 1; i <= Amount; i++)
        {
            // Recebe os dados do personagem
            Lists.Class[i] = new Lists.Structures.Class();
            Lists.Class[i].Name = Data.ReadString();
            Lists.Class[i].Texture_Male = Data.ReadInt16();
            Lists.Class[i].Texture_Female = Data.ReadInt16();
        }
    }

    private static void Characters(NetIncomingMessage Data)
    {
        byte Amount = Data.ReadByte();

        // Redimensiona a lista
        Lists.Server_Data.Max_Characters = Amount;
        Lists.Characters = new Lists.Structures.Characters[Amount + 1];

        for (byte i = 1; i <= Amount; i++)
        {
            // Recebe os dados do personagem
            Lists.Characters[i] = new Lists.Structures.Characters();
            Lists.Characters[i].Name = Data.ReadString();
            Lists.Characters[i].Class = Data.ReadByte();
            Lists.Characters[i].Genre = Data.ReadBoolean();
            Lists.Characters[i].Level = Data.ReadInt16();
        }
    }

    private static void JoinGame(NetIncomingMessage Data)
    {
        // Reseta os valores
        Tools.Chat = new System.Collections.Generic.List<Tools.Chat_Structure>();
        TextBoxes.Find("Chat").Text = string.Empty;
        Panels.Find("Chat").General.Visible = false;
        Tools.Chat_Line = 0;

        // Abre o jogo
        Audio.Music.Stop();
        Tools.CurrentWindow = Tools.Windows.Game;
    }

    private static void HigherIndex(NetIncomingMessage Data)
    {
        // Define o número maior de índice
        Player.HigherIndex = Data.ReadByte();
    }

    public static void Map_Revision(NetIncomingMessage Data)
    {
        bool Needed = false;
        short Map_Num = Data.ReadInt16();

        // Limpa todos os outros jogadores
        for (byte i = 1; i <= Player.HigherIndex; i++)
            if (i != Player.MyIndex)
                Clear.Player(i);

        // Verifica se é necessário baixar os dados do mapa
        if (System.IO.File.Exists(Directories.Maps_Data.FullName + Map_Num + Directories.Format))
        {
            Read.Map(Map_Num);
            if (Lists.Map.Revision != Data.ReadInt16())
                Needed = true;
        }
        else
            Needed = true;

        // Solicita os dados do mapa
        Send.RequestMap(Needed);
    }

    public static void Map(NetIncomingMessage Data)
    {
        // Define os dados
        short Mapa_Num = Data.ReadInt16();
        Lists.Map.Revision = Data.ReadInt16();
        Lists.Map.Name = Data.ReadString();
        Lists.Map.Width = Data.ReadByte();
        Lists.Map.Height = Data.ReadByte();
        Lists.Map.Moral = Data.ReadByte();
        Lists.Map.Panorama = Data.ReadByte();
        Lists.Map.Music = Data.ReadByte();
        Lists.Map.Color = Data.ReadInt32();
        Lists.Map.Weather.Type = Data.ReadByte();
        Lists.Map.Weather.Intensity = Data.ReadByte();
        Lists.Map.Fog.Texture = Data.ReadByte();
        Lists.Map.Fog.Speed_X = Data.ReadSByte();
        Lists.Map.Fog.Speed_Y = Data.ReadSByte();
        Lists.Map.Fog.Alpha = Data.ReadByte();

        // Redimensiona as ligações
        Lists.Map.Link = new short[(byte)Game.Directions.Amount];

        for (short i = 0; i <= (short)Game.Directions.Amount - 1; i++)
            Lists.Map.Link[i] = Data.ReadInt16();

        // Redimensiona os azulejos
        Lists.Map.Tile = new Lists.Structures.Map_Tile[Lists.Map.Width + 1, Lists.Map.Height + 1];

        // Lê os dados
        byte NumLayers = Data.ReadByte();
        for (byte x = 0; x <= Lists.Map.Width; x++)
            for (byte y = 0; y <= Lists.Map.Height; y++)
            {
                // Redimensiona os dados dos azulejos
                Lists.Map.Tile[x, y].Data = new Lists.Structures.Map_Tile_Data[(byte)global::Map.Layers.Amount, NumLayers + 1];

                for (byte c = 0; c <= (byte)global::Map.Layers.Amount - 1; c++)
                    for (byte q = 0; q <= NumLayers; q++)
                    {
                        Lists.Map.Tile[x, y].Data[c, q].x = Data.ReadByte();
                        Lists.Map.Tile[x, y].Data[c, q].y = Data.ReadByte();
                        Lists.Map.Tile[x, y].Data[c, q].Tile = Data.ReadByte();
                        Lists.Map.Tile[x, y].Data[c, q].Automatic = Data.ReadBoolean();
                        Lists.Map.Tile[x, y].Data[c, q].Mini = new Point[4];
                    }
            }

        // Data específicos dos azulejos
        for (byte x = 0; x <= Lists.Map.Width; x++)
            for (byte y = 0; y <= Lists.Map.Height; y++)
            {
                Lists.Map.Tile[x, y].Attribute = Data.ReadByte();
                Lists.Map.Tile[x, y].Block = new bool[(byte)Game.Directions.Amount];
                for (byte i = 0; i <= (byte)Game.Directions.Amount - 1; i++)
                    Lists.Map.Tile[x, y].Block[i] = Data.ReadBoolean();
            }

        // Luzes
        Lists.Map.Light = new Lists.Structures.Map_Light[Data.ReadInt32() + 1];
        if (Lists.Map.Light.GetUpperBound(0) > 0)
            for (byte i = 0; i <= Lists.Map.Light.GetUpperBound(0); i++)
            {
                Lists.Map.Light[i].X = Data.ReadByte();
                Lists.Map.Light[i].Y = Data.ReadByte();
                Lists.Map.Light[i].Width = Data.ReadByte();
                Lists.Map.Light[i].Height = Data.ReadByte();
            }

        // NPCs
        Lists.Map.NPC = new short[Data.ReadInt16() + 1];
        if (Lists.Map.NPC.GetUpperBound(0) > 0)
            for (byte i = 1; i <= Lists.Map.NPC.GetUpperBound(0); i++)
                Lists.Map.NPC[i] = Data.ReadInt16();

        // Salva o mapa
        Write.Map(Mapa_Num);

        // Redimensiona as partículas do clima
        global::Map.Weather_Update();
        global::Map.Autotile.Update();
    }

    public static void JoinMap(NetIncomingMessage Data)
    {
        // Se tiver, reproduz a música de fundo do mapa
        if (Lists.Map.Music > 0)
            Audio.Music.Play((Audio.Musics)Lists.Map.Music);
        else
            Audio.Music.Stop();
    }

    public static void Latency(NetIncomingMessage Data)
    {
        // Define a latência
        Game.Latency = Environment.TickCount - Game.Latency_Send;
    }

    public static void Message(NetIncomingMessage Data)
    {
        // Adiciona a mensagem
        string Text = Data.ReadString();
        Color Color = Color.FromArgb(Data.ReadInt32());
        Tools.Chat_Add(Text, new SFML.Graphics.Color(Color.R, Color.G, Color.B));
    }

    public static void Items(NetIncomingMessage Data)
    {
        // Quantidade
        Lists.Item = new Lists.Structures.Items[Data.ReadByte() + 1];

        for (byte i = 1; i <= Lists.Item.GetUpperBound(0); i++)
        {
            // Redimensiona os valores necessários 
            Lists.Item[i].Potion_Vital = new short[(byte)Game.Vitals.Amount];
            Lists.Item[i].Equip_Attribute = new short[(byte)Game.Attributes.Amount];

            // Lê os dados
            Lists.Item[i].Name = Data.ReadString();
            Lists.Item[i].Description = Data.ReadString();
            Lists.Item[i].Texture = Data.ReadInt16();
            Lists.Item[i].Type = Data.ReadByte();
            Lists.Item[i].Req_Level = Data.ReadInt16();
            Lists.Item[i].Req_Class = Data.ReadByte();
            Lists.Item[i].Potion_Experience = Data.ReadInt16();
            for (byte n = 0; n <= (byte)Game.Vitals.Amount - 1; n++) Lists.Item[i].Potion_Vital[n] = Data.ReadInt16();
            Lists.Item[i].Equip_Type = Data.ReadByte();
            for (byte n = 0; n <= (byte)Game.Attributes.Amount - 1; n++) Lists.Item[i].Equip_Attribute[n] = Data.ReadInt16();
            Lists.Item[i].Weapon_Damage = Data.ReadInt16();
        }
    }

    public static void Map_Items(NetIncomingMessage Data)
    {
        // Quantidade
        Lists.Map.Temp_Item = new Lists.Structures.Map_Items[Data.ReadInt16() + 1];

        // Lê os dados de todos
        for (byte i = 1; i <= Lists.Map.Temp_Item.GetUpperBound(0); i++)
        {
            // Geral
            Lists.Map.Temp_Item[i].Index = Data.ReadInt16();
            Lists.Map.Temp_Item[i].X = Data.ReadByte();
            Lists.Map.Temp_Item[i].Y = Data.ReadByte();
        }
    }
}
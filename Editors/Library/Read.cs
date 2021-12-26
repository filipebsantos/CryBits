﻿using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CryBits.Editors.Entities;
using CryBits.Editors.Entities.Tools;
using static CryBits.Editors.Logic.Options;
using Button = CryBits.Editors.Entities.Tools.Button;
using CheckBox = CryBits.Editors.Entities.Tools.CheckBox;
using Graphics = CryBits.Editors.Media.Graphics;
using Panel = CryBits.Editors.Entities.Tools.Panel;
using TextBox = CryBits.Editors.Entities.Tools.TextBox;

namespace CryBits.Editors.Library
{
    internal static class Read
    {
        public static void Options()
        {
            // Cria o arquivo se ele não existir
            if (!Directories.Options.Exists)
            {
                Write.Options();
                return;
            }

            // Carrega as configurações
            using (var data = new BinaryReader(Directories.Options.OpenRead()))
            {
                PreMapGrid = data.ReadBoolean();
                PreMapView = data.ReadBoolean();
                PreMapAudio = data.ReadBoolean();
                Username = data.ReadString();
            }
        }

        public static void Tools()
        {
            FileInfo file = new FileInfo(Directories.Tools.FullName);

            // Limpa a árvore de ordem
            Tool.Tree = new TreeNode();
            for (byte i = 0; i < Enum.GetValues(typeof(WindowsTypes)).Length; i++) Tool.Tree.Nodes.Add(((WindowsTypes)i).ToString());

            // Cria o arquivo caso ele não existir
            if (!file.Exists)
            {
                Write.Tools();
                return;
            }

            // Cria um sistema binário para a manipulação dos dados
            using (var data = new BinaryReader(file.OpenRead()))
                // Lê todos os nós
                for (byte n = 0; n < Tool.Tree.Nodes.Count; n++)
                    Tools(Tool.Tree.Nodes[n], data);
        }

        public static void Tools(TreeNode node, BinaryReader data)
        {
            // Lê todos os filhos
            byte size = data.ReadByte();
            for (byte i = 0; i < size; i++)
            {
                Tool temp = new Tool();
                ToolType type = (ToolType)data.ReadByte();

                // Lê a ferramenta
                if (type == ToolType.Button) temp = Button(data);
                else if (type == ToolType.CheckBox) temp = CheckBox(data);
                else if (type == ToolType.Panel) temp = Panel(data);
                else if (type == ToolType.TextBox) temp = TextBox(data);

                // Adiciona o nó
                node.Nodes.Add("[" + type + "] " + temp.Name);
                node.LastNode.Tag = temp;

                // Pula pro próximo
                Tools(node.Nodes[i], data);
            }
        }

        private static Button Button(BinaryReader data)
        {
            // Lê os dados
            return new Button
            {
                Name = data.ReadString(),
                Position = new Point(data.ReadInt32(), data.ReadInt32()),
                Visible = data.ReadBoolean(),
                Window = (WindowsTypes)data.ReadByte(),
                TextureNum = data.ReadByte()
            };
        }

        private static TextBox TextBox(BinaryReader data)
        {
            // Lê os dados
            return new TextBox
            {
                Name = data.ReadString(),
                Position = new Point(data.ReadInt32(), data.ReadInt32()),
                Visible = data.ReadBoolean(),
                Window = (WindowsTypes)data.ReadByte(),
                MaxCharacters = data.ReadInt16(),
                Width = data.ReadInt16(),
                Password = data.ReadBoolean()
            };
        }

        private static Panel Panel(BinaryReader data)
        {
            // Carrega os dados
            return new Panel
            {
                Name = data.ReadString(),
                Position = new Point(data.ReadInt32(), data.ReadInt32()),
                Visible = data.ReadBoolean(),
                Window = (WindowsTypes)data.ReadByte(),
                TextureNum = data.ReadByte()
            };
        }

        private static CheckBox CheckBox(BinaryReader data)
        {
            // Carrega os dados
            return new CheckBox
            {
                Name = data.ReadString(),
                Position = new Point(data.ReadInt32(), data.ReadInt32()),
                Visible = data.ReadBoolean(),
                Window = (WindowsTypes)data.ReadByte(),
                Text = data.ReadString(),
                Checked = data.ReadBoolean()
            };
        }

        public static void Tiles()
        {
            // Lê os dados
            Entities.Tile.List = new Tile[Graphics.TexTile.Length];
            for (byte i = 1; i < Entities.Tile.List.Length; i++) Tile(i);
        }

        private static void Tile(byte index)
        {
            FileInfo file = new FileInfo(Directories.Tiles.FullName + index + Directories.Format);

            // Evita erros
            if (!file.Exists)
            {
                Entities.Tile.List[index] = new Tile(index);
                Write.Tile(index);
                return;
            }

            // Lê os dados
            using (var stream = file.OpenRead())
                Entities.Tile.List[index] = (Tile)new BinaryFormatter().Deserialize(stream);
        }
    }
}
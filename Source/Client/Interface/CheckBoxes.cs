﻿using System.Collections.Generic;
using System.Drawing;
using Library;

namespace Interface
{
    class CheckBoxes
    {
        // Armazenamento dos dados da ferramenta
        public static List<Structure> List = new List<Structure>();

        // Margem da textura até o texto
        public const byte Margin = 4;

        // Estrutura da ferramenta
        public class Structure : Tools.Structure
        {
            // Dados
            public string Text;
            public bool Checked;

            // Eventos
            public void MouseUp()
            {
                // Tamanho do marcador
                Size Texture_Size = Graphics.TSize(Graphics.Tex_CheckBox);
                Size Box = new Size(Texture_Size.Width / 2 + Utils.MeasureString(Text) + Margin, Texture_Size.Height);

                // Somente se estiver sobrepondo a ferramenta
                if (!Utils.IsAbove(new Rectangle(Position, Box))) return;

                // Altera o estado do marcador
                Checked = !Checked;

                // Executa o evento
                Execute(Name);
                Audio.Sound.Play(Audio.Sounds.Click);
            }
        }

        // Retorna a caixa de marcação procurada
        public static Structure Get(string Name) => List.Find(x => x.Name.Equals(Name));

        private static void Execute(string Name)
        {
            // Executa o evento do marcador
            switch (Name)
            {
                case "Sounds": Sounds(); break;
                case "Musics": Musics(); break;
                case "Connect_Save_Username": SaveUsername(); break;
                case "GenderMale": GenreName(); break;
                case "GenderFemale": GenreFemale(); break;
                case "Options_Sounds": Sounds(); break;
                case "Options_Musics": Musics(); break;
                case "Options_Chat": Chat(); break;
                case "Options_FPS": FPS(); break;
                case "Options_Latency": Latency(); break;
                case "Options_Party": Party(); break;
                case "Options_Trade": Trade(); break;
            }
        }

        private static void Sounds()
        {
            // Salva os dados
            Utils.Option.Sounds = !Utils.Option.Sounds;
            if (!Utils.Option.Sounds) Audio.Sound.Stop_All();
            Write.Options();
        }

        private static void Musics()
        {
            // Salva os dados
            Utils.Option.Musics = !Utils.Option.Musics;
            Write.Options();

            // Para ou reproduz a música dependendo do estado do marcador
            if (!Utils.Option.Musics)
                Audio.Music.Stop();
            else if (Windows.Current == Windows.Types.Menu)
                Audio.Music.Play(Audio.Musics.Menu);
            else if (Windows.Current == Windows.Types.Game)
                Audio.Music.Play((Audio.Musics)Mapper.Current.Data.Music);
        }

        private static void SaveUsername()
        {
            // Salva os dados
            Utils.Option.SaveUsername = Get("Connect_Save_Username").Checked;
            Write.Options();
        }

        private static void GenreName()
        {
            // Altera o estado do marcador de outro gênero
            Get("GenderFemale").Checked = !Get("GenderMale").Checked;
            Panels.CreateCharacter_Tex = 0;
        }

        private static void GenreFemale()
        {
            // Altera o estado do marcador de outro gênero
            Get("GenderMale").Checked = !Get("GenderFemale").Checked;
            Panels.CreateCharacter_Tex = 0;
        }

        private static void Chat()
        {
            // Salva os dado
            Utils.Option.Chat = Get("Options_Chat").Checked;
            Write.Options();
            if (Utils.Option.Chat) Loop.Chat_Timer = System.Environment.TickCount + Interface.Chat.Sleep_Timer;
        }

        private static void FPS()
        {
            // Salva os dado
            Utils.Option.FPS = Get("Options_FPS").Checked;
            Write.Options();
        }

        private static void Latency()
        {
            // Desabilita a prévia do chat
            Utils.Option.Latency = Get("Options_Latency").Checked;
            Write.Options();
        }

        private static void Party()
        {
            // Salva os dado
            Utils.Option.Party = Get("Options_Party").Checked;
            Write.Options();
        }

        private static void Trade()
        {
            // Salva os dado
            Utils.Option.Trade = Get("Options_Trade").Checked;
            Write.Options();
        }
    }
}
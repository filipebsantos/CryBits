﻿using CryBits.Client.Entities;
using CryBits.Client.Interface;
using System;
using System.Windows.Forms;

namespace CryBits.Client.Logic
{
    class Loop
    {
        // Contagens
        public static int TextBox_Timer = 0;
        public static int Chat_Timer = 0;

        public static void Init()
        {
            int Timer_1000 = 0;
            int Timer_30 = 0;
            short FPS = 0;

            while (Program.Working)
            {
                // Manuseia os dados recebidos
                Network.Socket.HandleData();

                // Apresenta os gráficos à tela
                Graphics.Present();

                // Processa os eventos da janela
                Graphics.RenderWindow.DispatchEvents();

                // Eventos
                TextBox();

                if (Windows.Current == WindowsTypes.Game)
                {
                    Mapper.Logic();
                    if (Timer_30 < Environment.TickCount)
                    {
                        // Lógica dos jogadores
                        for (byte i = 0; i < Player.List.Count; i++)
                            Player.List[i].Logic();

                        // Lógica dos NPCs
                        for (byte i = 0; i < Mapper.Current.NPC.Length; i++)
                            if (Mapper.Current.NPC[i].Data != null)
                                Mapper.Current.NPC[i].Logic();

                        // Reinicia a contagem
                        Timer_30 = Environment.TickCount + 30;
                    }

                    // Verifica se é necessário mostrar o painel de informações
                    Panels.CheckInformations();
                }

                // Faz com que a aplicação se mantenha estável
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);

                // Cálcula o FPS
                if (Timer_1000 < Environment.TickCount)
                {
                    Network.Send.Latency();
                    Game.FPS = FPS;
                    FPS = 0;
                    Timer_1000 = Environment.TickCount + 1000;
                }
                else
                    FPS += 1;
            }

            // Fecha o jogo
            Program.Close();
        }

        private static void TextBox()
        {
            // Contagem para a renderização da referência do último texto
            if (TextBox_Timer < Environment.TickCount)
            {
                TextBox_Timer = Environment.TickCount + 500;
                TextBoxes.Signal = !TextBoxes.Signal;

                // Se necessário foca o digitalizador de novo
                TextBoxes.Focus();
            }
        }
    }
}
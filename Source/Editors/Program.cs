﻿using System;
using System.Windows.Forms;

class Program
{
    // Usado para manter a aplicação aberta
    public static bool Working = true;

    [STAThread]
    static void Main()
    {
        // Abre a janela de seleção de diretório do cliente caso não houver um
        if (!Directories.Options.Exists && !Directories.Select())
            return;
        else
            Read.Options();

        // Inicia o dispositivo de rede
        Socket.Init();

        // Inicia a aplicação
        Login.Form.Visible = true;
        Application.EnableVisualStyles();
        Loop.Init();
    }

    public static void Close()
    {
        int Wait_Timer = Environment.TickCount;

        // Desconecta da rede
        Socket.Disconnect();

        // Espera até que o jogador seja desconectado
        while (Socket.IsConnected() && Environment.TickCount <= Wait_Timer + 1000)
            Application.DoEvents();

        // Fecha a aplicação
        Application.Exit();
    }
}
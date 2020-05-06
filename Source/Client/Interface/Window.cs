﻿using System;
using System.Collections.Generic;
using SFML.Window;

class Window
{
    // Detecção de duplo clique
    private static int DoubleClick_Timer;

    public static void OnClosed(object sender, EventArgs e)
    {
        // Fecha o jogo
        if (Tools.CurrentWindow == Tools.Windows.Game)
            Socket.Disconnect();
        else
            Program.Working = false;
    }

    public static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
    {
        // Clique duplo
        if (Environment.TickCount < DoubleClick_Timer + 142)
        {
            if (Tools.CurrentWindow == Tools.Windows.Game)
            {
                // Usar item
                short Slot = Panels.Inventory_Slot;
                if (Slot > 0)
                    if (Player.Me.Inventory[Slot].Item_Num > 0)
                        Send.Inventory_Use((byte)Slot);

                // Usar o que estiver na hotbar
                Slot = Panels.Hotbar_Slot;
                if (Slot > 0)
                    if (Player.Me.Hotbar[Slot].Slot > 0)
                        Send.Hotbar_Use((byte)Slot);

                // Compra o item da loja
                Slot = Panels.Shop_Slot;
                if (Slot >= 0)
                    if (Tools.Shop_Open > 0)
                        Send.Shop_Buy((byte)Slot);
            }
        }
        // Clique único
        else
        {
            // Percorre toda a árvore de ordem para executar o comando
            Stack<List<Tools.Order_Structure>> Stack = new Stack<List<Tools.Order_Structure>>();
            Stack.Push(Tools.Order);
            while (Stack.Count != 0)
            {
                List<Tools.Order_Structure> Top = Stack.Pop();

                for (byte i = 0; i < Top.Count; i++)
                    if (Top[i].Data.Visible)
                    {
                        // Executa o comando
                        if (Top[i].Data is Buttons.Structure) ((Buttons.Structure)Top[i].Data).MouseDown(e);
                        Stack.Push(Top[i].Nodes);
                    }
            }

            // Eventos em jogo
            if (Tools.CurrentWindow == Tools.Windows.Game)
            {
                Panels.Inventory_MouseDown(e);
                Panels.Equipment_MouseDown(e);
                Panels.Hotbar_MouseDown(e);
                Panels.Trade_MouseDown(e);
            }
        }
    }

    public static void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
    {
        // Contagem do clique duplo
        DoubleClick_Timer = Environment.TickCount;

        // Percorre toda a árvore de ordem para executar o comando
        Stack<List<Tools.Order_Structure>> Stack = new Stack<List<Tools.Order_Structure>>();
        Stack.Push(Tools.Order);
        while (Stack.Count != 0)
        {
            List<Tools.Order_Structure> Top = Stack.Pop();

            for (byte i = 0; i < Top.Count; i++)
                if (Top[i].Data.Visible)
                {
                    // Executa o comando
                    if (Top[i].Data is Buttons.Structure) ((Buttons.Structure)Top[i].Data).MouseUp();
                    else if (Top[i].Data is CheckBoxes.Structure) ((CheckBoxes.Structure)Top[i].Data).MouseUp();
                    else if (Top[i].Data is TextBoxes.Structure) ((TextBoxes.Structure)Top[i].Data).MouseUp(Top[i]);
                    Stack.Push(Top[i].Nodes);
                }
        }

        // Eventos em jogo
        if (Tools.CurrentWindow == Tools.Windows.Game)
        {
            // Muda o slot do item
            if (Panels.Inventory_Slot > 0)
            {
                if (Tools.Inventory_Change > 0) Send.Inventory_Change(Tools.Inventory_Change, Panels.Inventory_Slot);
            }
            // Muda o slot da hotbar
            else if (Panels.Hotbar_Slot > 0)
            {
                if (Tools.Hotbar_Change > 0) Send.Hotbar_Change(Tools.Hotbar_Change, Panels.Hotbar_Slot);
                if (Tools.Inventory_Change > 0) Send.Hotbar_Add(Panels.Hotbar_Slot, (byte)Game.Hotbar.Item, Tools.Inventory_Change);
            }
            // Adiciona um item à troca
            else if (Panels.Trade_Slot > 0)
            {
                if (Tools.Inventory_Change > 0)
                    if (Player.Me.Inventory[Tools.Inventory_Change].Amount == 1)
                        Send.Trade_Offer(Panels.Trade_Slot, Tools.Inventory_Change);
                    else
                    {
                        Tools.Trade_Slot = Panels.Trade_Slot;
                        Tools.Trade_Inventory_Slot = Tools.Inventory_Change;
                        TextBoxes.Get("Trade_Amount").Text = string.Empty;
                        Panels.Get("Trade_Amount").Visible = true;
                    }
            }

            // Reseta a movimentação
            Tools.Inventory_Change = 0;
            Tools.Hotbar_Change = 0;
        }
    }

    public static void OnMouseMoved(object sender, MouseMoveEventArgs e)
    {
        // Define a posição do mouse à váriavel
        Tools.Mouse.X = e.X;
        Tools.Mouse.Y = e.Y;

        // Percorre toda a árvore de ordem para executar o comando
        Stack<List<Tools.Order_Structure>> Stack = new Stack<List<Tools.Order_Structure>>();
        Stack.Push(Tools.Order);
        while (Stack.Count != 0)
        {
            List<Tools.Order_Structure> Top = Stack.Pop();

            for (byte i = 0; i < Top.Count; i++)
                if (Top[i].Data.Visible)
                {
                    // Executa o comando
                    if (Top[i].Data is Buttons.Structure) ((Buttons.Structure)Top[i].Data).MouseMove();
                    Stack.Push(Top[i].Nodes);
                }
        }
    }

    public static void OnKeyPressed(object sender, KeyEventArgs e)
    {
        // Define se um botão está sendo pressionado
        switch (e.Code)
        {
            case Keyboard.Key.Tab: TextBoxes.ChangeFocus(); return;
        }
    }

    public static void OnKeyReleased(object sender, KeyEventArgs e)
    {
        // Define se um botão está sendo pressionado
        if (Tools.CurrentWindow == Tools.Windows.Game)
            switch (e.Code)
            {
                case Keyboard.Key.Enter: Chat.Type(); break;
                case Keyboard.Key.Space: Player.Me.CollectItem(); break;
                case Keyboard.Key.Num1: Send.Hotbar_Use(1); break;
                case Keyboard.Key.Num2: Send.Hotbar_Use(2); break;
                case Keyboard.Key.Num3: Send.Hotbar_Use(3); break;
                case Keyboard.Key.Num4: Send.Hotbar_Use(4); break;
                case Keyboard.Key.Num5: Send.Hotbar_Use(5); break;
                case Keyboard.Key.Num6: Send.Hotbar_Use(6); break;
                case Keyboard.Key.Num7: Send.Hotbar_Use(7); break;
                case Keyboard.Key.Num8: Send.Hotbar_Use(8); break;
                case Keyboard.Key.Num9: Send.Hotbar_Use(9); break;
                case Keyboard.Key.Num0: Send.Hotbar_Use(0); break;
            }
    }

    public static void OnTextEntered(object sender, TextEventArgs e)
    {
        // Executa os eventos
        if (TextBoxes.Focused != null) ((TextBoxes.Structure)TextBoxes.Focused.Data).TextEntered(e);
    }

    public static void OpenMenu()
    {
        // Reproduz a música de fundo
        Audio.Sound.Stop_All();
        if (Lists.Options.Musics) Audio.Music.Play(Audio.Musics.Menu);

        // Traz o jogador de volta ao menu
        Panels.Menu_Close();
        Panels.Get("Connect").Visible = true;
        Tools.CurrentWindow = Tools.Windows.Menu;
    }
}
﻿using System;
using System.Drawing;
using CryBits.Client.Entities;
using CryBits.Client.Framework.Constants;
using CryBits.Client.Framework.Interfacily.Components;
using CryBits.Client.Network;
using CryBits.Entities.Shop;
using CryBits.Enums;
using CryBits.Extensions;
using SFML.Window;
using static CryBits.Client.Framework.Interfacily.InterfaceUtils;

namespace CryBits.Client.UI.Events;

internal static class PanelsEvents
{
    // Dados temporários
    public static byte CreateCharacterClass = 0;
    public static byte CreateCharacterTex = 0;
    public static int SelectCharacter = 1;
    public static Guid InformationId;
    public static short DropSlot;
    public static string PartyInvitation;
    public static string TradeInvitation;
    public static short TradeInventorySlot = -1;
    public static Shop ShopOpen;
    public static short ShopInventorySlot;
    public static short HotbarChange;
    public static short InventoryChange;
    public static TempCharacter[] Characters;
    public struct TempCharacter
    {
        public string Name;
        public short TextureNum;
    }

    public static void Bind()
    {
        Panels.MenuCharacter.OnMouseDown += Equipment_MouseDown;
        Panels.MenuInventory.OnMouseDown += Inventory_MouseDown;
        Panels.MenuInventory.OnMouseUp += Inventory_MouseUp;
        Panels.MenuInventory.OnMouseDoubleClick += Inventory_MouseDoubleClick;
        Panels.Hotbar.OnMouseDown += Hotbar_MouseDown;
        Panels.Hotbar.OnMouseUp += Hotbar_MouseUp;
        Panels.Hotbar.OnMouseDoubleClick += Hotbar_MouseDoubleClick;
        Panels.Trade.OnMouseDown += Trade_MouseDown;
        Panels.Trade.OnMouseUp += Trade_MouseUp;
        Panels.Trade.OnMouseDoubleClick += Trade_MouseDoubleClick;
    }

    public static void MenuClose()
    {
        // Fecha todos os paineis abertos
        Panels.Connect.Visible = false;
        Panels.Register.Visible = false;
        Panels.Options.Visible = false;
        Panels.SelectCharacter.Visible = false;
        Panels.CreateCharacter.Visible = false;
    }

    public static short Slot(Panel panel, byte offX, byte offY, byte lines, byte columns, byte grid = 32, byte gap = 4)
    {
        var size = grid + gap;
        var start = panel.Position + new Size(offX, offY);
        var slot = new Point((Window.Mouse.X - start.X) / size, (Window.Mouse.Y - start.Y) / size);

        // Verifica se o Window.Mouse está sobre o slot
        if (slot.Y < 0 || slot.X < 0 || slot.X >= columns || slot.Y >= lines) return -1;
        if (!IsAbove(new Rectangle(start.X + slot.X * size, start.Y + slot.Y * size, grid, grid))) return -1;
        if (!panel.Visible) return -1;

        // Retorna o slot
        return (short)(slot.Y * columns + slot.X);
    }

    // Retorna em qual slot o mouse está sobrepondo
    public static short InventorySlot => Slot(Panels.MenuInventory, 7, 29, 6, 5);
    public static short HotbarSlot => Slot(Panels.Hotbar, 8, 6, 1, 10);
    public static short TradeSlot => Slot(Panels.Trade, 7, 50, 6, 5);
    public static short ShopSlot => Slot(Panels.Shop, 7, 50, 4, 7);
    public static short EquipmentSlot => Slot(Panels.MenuCharacter, 7, 248, 1, 5);

    public static void Inventory_MouseDown(MouseButtonEventArgs e)
    {
        var slot = InventorySlot;

        // Somente se necessário
        if (slot == -1) return;
        if (Player.Me.Inventory[slot].Item == null) return;

        switch (e.Button)
        {
            case Mouse.Button.Right:
            {
                if (Player.Me.Inventory[slot].Item.Bind != BindOn.Pickup)
                    // Vende o item
                    if (Panels.Shop.Visible)
                    {
                        if (Player.Me.Inventory[slot].Amount != 1)
                        {
                            ShopInventorySlot = slot;
                            TextBoxes.ShopSellAmount.Text = string.Empty;
                            Panels.ShopSell.Visible = true;
                        }
                        else Send.ShopSell(slot, 1);
                    }
                    // Solta o item
                    else if (!Panels.Trade.Visible)
                        if (Player.Me.Inventory[slot].Amount != 1)
                        {
                            DropSlot = slot;
                            TextBoxes.DropAmount.Text = string.Empty;
                            Panels.Drop.Visible = true;
                        }
                        else Send.DropItem(slot, 1);

                break;
            }
            // Seleciona o item
            case Mouse.Button.Left:
                InventoryChange = slot;
                break;
        }
    }

    public static void Equipment_MouseDown(MouseButtonEventArgs e)
    {
        var panelPosition = Panels.MenuCharacter.Position;

        for (byte i = 0; i < (byte)Equipment.Count; i++)
            if (IsAbove(new Rectangle(panelPosition.X + 7 + i * 36, panelPosition.Y + 247, 32, 32)))
                // Remove o equipamento
                if (e.Button == Mouse.Button.Right)
                    if (Player.Me.Equipment[i]?.Bind != BindOn.Equip)
                    {
                        Send.EquipmentRemove(i);
                        return;
                    }
    }

    public static void Hotbar_MouseDown(MouseButtonEventArgs e)
    {
        var slot = HotbarSlot;

        // Somente se necessário
        if (slot < 0) return;
        if (Player.Me.Hotbar[slot].Slot == 0) return;

        switch (e.Button)
        {
            // Solta item
            case Mouse.Button.Right:
                Send.HotbarAdd(slot, 0, 0);
                break;
            // Seleciona o item
            case Mouse.Button.Left:
                HotbarChange = slot;
                break;
        }
    }

    public static void Trade_MouseDown(MouseButtonEventArgs e)
    {
        var slot = TradeSlot;

        // Somente se necessário
        if (!Panels.Trade.Visible) return;
        if (slot == -1) return;
        if (Player.Me.TradeOffer[slot].Item == null) return;

        // Solta item
        if (e.Button == Mouse.Button.Right) Send.TradeOffer(slot, 0);
    }

    public static void CheckInformation()
    {
        var position = new Point();

        // Define as informações do painel com base no que o Window.Mouse está sobrepondo
        if (HotbarSlot >= 0)
        {
            position = Panels.Hotbar.Position + new Size(0, 42);
            InformationId = Player.Me.Inventory[Player.Me.Hotbar[HotbarSlot].Slot].Item.GetId();
        }
        else if (InventorySlot > 0)
        {
            position = Panels.MenuInventory.Position + new Size(-186, 3);
            InformationId = Player.Me.Inventory[InventorySlot].Item.GetId();
        }
        else if (EquipmentSlot >= 0)
        {
            position = Panels.MenuCharacter.Position + new Size(-186, 5);
            InformationId = Player.Me.Equipment[EquipmentSlot].GetId();
        }
        else if (ShopSlot >= 0 && ShopSlot < ShopOpen.Sold.Count)
        {
            position = new Point(Panels.Shop.Position.X - 186, Panels.Shop.Position.Y + 5);
            InformationId = ShopOpen.Sold[ShopSlot].Item.GetId();
        }
        else InformationId = Guid.Empty;

        // Define os dados do painel de informações
        Panels.Information.Visible = !position.IsEmpty && InformationId != Guid.Empty;
        Panels.Information.Position = position;
    }

    public static void Inventory_MouseUp()
    {
        // Somente se necessário
        if (InventorySlot == 0) return;
        if (InventoryChange == 0) return;

        // Muda o slot do item
        Send.InventoryChange(InventoryChange, InventorySlot);
    }

    public static void Hotbar_MouseUp()
    {
        // Muda o slot da hotbar
        if (HotbarSlot < 0) return;
        if (HotbarChange >= 0) Send.HotbarChange(HotbarChange, HotbarSlot);
        if (InventoryChange > 0) Send.HotbarAdd(HotbarSlot, (byte)SlotType.Item, InventoryChange);
    }

    public static void Trade_MouseUp()
    {
        if (InventoryChange <= 0) return;

        // Adiciona um item à troca
        if (Player.Me.Inventory[InventoryChange].Amount == 1)
            Send.TradeOffer(TradeSlot, InventoryChange);
        else
        {
            TradeInventorySlot = InventoryChange;
            TextBoxes.TradeAmount.Text = string.Empty;
            Panels.TradeAmount.Visible = true;
        }
    }

    public static void Inventory_MouseDoubleClick(MouseButtonEventArgs e)
    {
        var slot = InventorySlot;
        if (slot <= 0) return;
        if (Player.Me.Inventory[slot].Item == null) return;

        // Usa o item
        Send.InventoryUse((byte)slot);
    }

    public static void Hotbar_MouseDoubleClick(MouseButtonEventArgs e)
    {
        var slot = HotbarSlot;
        if (slot <= 0) return;
        if (Player.Me.Hotbar[slot].Slot <= 0) return;

        // Usar o que estiver na hotbar
        Send.HotbarUse((byte)slot);
    }

    public static void Trade_MouseDoubleClick(MouseButtonEventArgs e)
    {
        var slot = ShopSlot;
        if (slot < 0) return;
        if (ShopOpen == null) return;

        // Compra o item da loja
        Send.ShopBuy((byte)slot);
    }
}
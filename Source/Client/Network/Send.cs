﻿using CryBits.Client.Entities;
using Lidgren.Network;
using System;
using System.Linq;
using CryBits.Client.UI;

namespace CryBits.Client.Network
{
    class Send
    {
        // Pacotes do cliente
        public enum Packets
        {
            Connect,
            Latency,
            Register,
            CreateCharacter,
            Character_Use,
            Character_Create,
            Character_Delete,
            Player_Direction,
            Player_Move,
            Player_Attack,
            RequestMap,
            Message,
            AddPoint,
            CollectItem,
            DropItem,
            Inventory_Change,
            Inventory_Use,
            Equipment_Remove,
            Hotbar_Add,
            Hotbar_Change,
            Hotbar_Use,
            Party_Invite,
            Party_Accept,
            Party_Decline,
            Party_Leave,
            Trade_Invite,
            Trade_Accept,
            Trade_Decline,
            Trade_Leave,
            Trade_Offer,
            Trade_Offer_State,
            Shop_Buy,
            Shop_Sell,
            Shop_Close
        }

        private static void Packet(NetOutgoingMessage data)
        {
            // Envia os dados ao servidor
            Socket.Device.SendMessage(data, NetDeliveryMethod.ReliableOrdered);
        }

        public static void Connect()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Connect);
            data.Write(TextBoxes.List["Connect_Username"].Text);
            data.Write(TextBoxes.List["Connect_Password"].Text);
            data.Write(false); // Acesso pelo cliente
            Packet(data);
        }

        public static void Register()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Register);
            data.Write(TextBoxes.List["Register_Username"].Text);
            data.Write(TextBoxes.List["Register_Password"].Text);
            Packet(data);
        }

        public static void CreateCharacter()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.CreateCharacter);
            data.Write(TextBoxes.List["CreateCharacter_Name"].Text);
            data.Write(Class.List.ElementAt(Panels.CreateCharacter_Class).Value.ID.ToString());
            data.Write(CheckBoxes.List["GenderMale"].Checked);
            data.Write(Panels.CreateCharacter_Tex);
            Packet(data);
        }

        public static void Character_Use()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Character_Use);
            data.Write(Panels.SelectCharacter);
            Packet(data);
        }

        public static void Character_Create()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Character_Create);
            Packet(data);
        }

        public static void Character_Delete()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Character_Delete);
            data.Write(Panels.SelectCharacter);
            Packet(data);
        }

        public static void RequestMap(bool order)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.RequestMap);
            data.Write(order);
            Packet(data);
        }

        public static void Latency()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Latency);
            Packet(data);

            // Define a contaem na hora do envio
            Socket.Latency_Send = Environment.TickCount;
        }

        public static void Message(string message, Messages type, string addressee = "")
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Message);
            data.Write(message);
            data.Write((byte)type);
            data.Write(addressee);
            Packet(data);
        }

        public static void AddPoint(Attributes attribute)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.AddPoint);
            data.Write((byte)attribute);
            Packet(data);
        }

        public static void CollectItem()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.CollectItem);
            Packet(data);
        }

        public static void DropItem(byte slot, short amount)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.DropItem);
            data.Write(slot);
            data.Write(amount);
            Packet(data);
        }

        public static void Inventory_Change(byte old, byte @new)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Inventory_Change);
            data.Write(old);
            data.Write(@new);
            Packet(data);

            // Fecha o painel de soltar item
            Panels.List["Drop"].Visible = false;
        }

        public static void Inventory_Use(byte slot)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Inventory_Use);
            data.Write(slot);
            Packet(data);

            // Fecha o painel de soltar item
            Panels.List["Drop"].Visible = false;
        }

        public static void Equipment_Remove(byte slot)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Equipment_Remove);
            data.Write(slot);
            Packet(data);
        }

        public static void Hotbar_Add(short hotbarSlot, byte type, byte slot)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Hotbar_Add);
            data.Write(hotbarSlot);
            data.Write(type);
            data.Write(slot);
            Packet(data);
        }

        public static void Hotbar_Change(short old, short @new)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Hotbar_Change);
            data.Write(old);
            data.Write(@new);
            Packet(data);
        }

        public static void Hotbar_Use(byte slot)
        {
            if (TextBoxes.Focused == null)
            {
                NetOutgoingMessage data = Socket.Device.CreateMessage();

                // Envia os dados
                data.Write((byte)Packets.Hotbar_Use);
                data.Write(slot);
                Packet(data);

                // Fecha o painel de soltar item
                Panels.List["Drop"].Visible = false;
            }
        }

        public static void Party_Invite(string playerName)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Party_Invite);
            data.Write(playerName);
            Packet(data);
        }

        public static void Party_Accept()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Party_Accept);
            Packet(data);
        }

        public static void Party_Decline()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Party_Decline);
            Packet(data);
        }

        public static void Party_Leave()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Party_Leave);
            Packet(data);
        }

        public static void Player_Direction()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Player_Direction);
            data.Write((byte)Player.Me.Direction);
            Packet(data);
        }

        public static void Player_Move()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Player_Move);
            data.Write(Player.Me.X);
            data.Write(Player.Me.Y);
            data.Write((byte)Player.Me.Movement);
            Packet(data);
        }

        public static void Player_Attack()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Player_Attack);
            Packet(data);
        }

        public static void Trade_Invite(string playerName)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Trade_Invite);
            data.Write(playerName);
            Packet(data);
        }

        public static void Trade_Accept()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Trade_Accept);
            Packet(data);
        }

        public static void Trade_Decline()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Trade_Decline);
            Packet(data);
        }

        public static void Trade_Leave()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Trade_Leave);
            Packet(data);
        }

        public static void Trade_Offer(byte slot, byte inventorySlot, short amount = 1)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Trade_Offer);
            data.Write(slot);
            data.Write(inventorySlot);
            data.Write(amount);
            Packet(data);
        }

        public static void Trade_Offer_State(TradeStatus state)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Trade_Offer_State);
            data.Write((byte)state);
            Packet(data);
        }

        public static void Shop_Buy(byte slot)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Shop_Buy);
            data.Write(slot);
            Packet(data);
        }

        public static void Shop_Sell(byte slot, short amount)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Shop_Sell);
            data.Write(slot);
            data.Write(amount);
            Packet(data);
        }

        public static void Shop_Close()
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)Packets.Shop_Close);
            Packet(data);
        }
    }
}
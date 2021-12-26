﻿using System.Drawing;
using CryBits.Entities;
using CryBits.Packets;
using CryBits.Server.Entities;
using Lidgren.Network;
using static CryBits.Defaults;
using static CryBits.Utils;

namespace CryBits.Server.Network
{
    internal static class Send
    {
        private static void ToPlayer(Account account, NetOutgoingMessage data)
        {
            // Recria o pacote e o envia
            NetOutgoingMessage dataSend = Socket.Device.CreateMessage(data.LengthBytes);
            dataSend.Write(data);
            Socket.Device.SendMessage(dataSend, account.Connection, NetDeliveryMethod.ReliableOrdered);
        }

        private static void ToPlayer(Player player, NetOutgoingMessage data)
        {
            ToPlayer(player.Account, data);
        }

        private static void ToAll(NetOutgoingMessage data)
        {
            // Envia os dados para todos conectados
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    ToPlayer(Account.List[i].Character, data);
        }

        private static void ToAllBut(Player player, NetOutgoingMessage data)
        {
            // Envia os dados para todos conectados, com excessão do índice
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (player != Account.List[i].Character)
                        ToPlayer(Account.List[i].Character, data);
        }

        private static void ToMap(TempMap map, NetOutgoingMessage data)
        {
            // Envia os dados para todos conectados, com excessão do índice
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (Account.List[i].Character.Map == map)
                        ToPlayer(Account.List[i].Character, data);
        }

        private static void ToMapBut(TempMap map, Player player, NetOutgoingMessage data)
        {
            // Envia os dados para todos conectados, com excessão do índice
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (Account.List[i].Character.Map == map)
                        if (player != Account.List[i].Character)
                            ToPlayer(Account.List[i].Character, data);
        }

        public static void Alert(Account account, string message, bool disconnect = true)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.Alert);
            else data.Write((byte)ServerClient.Alert);
            data.Write(message);
            ToPlayer(account, data);

            // Desconecta o jogador
            if (disconnect) account.Connection.Disconnect(string.Empty);
        }

        public static void Connect(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.Connect);
            else data.Write((byte)ServerClient.Connect);
            ToPlayer(account, data);
        }

        public static void CreateCharacter(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.CreateCharacter);
            ToPlayer(account, data);
        }

        public static void Join(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.Join);
            data.Write(player.Name);
            ToPlayer(player, data);
        }

        public static void Characters(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.Characters);
            data.Write((byte)account.Characters.Count);

            for (byte i = 0; i < account.Characters.Count; i++)
            {
                data.Write(account.Characters[i].Name);
                data.Write(account.Characters[i].TextureNum);
            }

            ToPlayer(account, data);
        }

        public static void Classes(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.Classes);
            else data.Write((byte)ServerClient.Classes);
            ObjectToByteArray(data, Class.List);
            ToPlayer(account, data);
        }

        public static void JoinGame(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.JoinGame);
            ToPlayer(player, data);
        }

        private static NetOutgoingMessage Player_Data_Cache(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Escreve os dados
            data.Write((byte)ServerClient.PlayerData);
            data.Write(player.Name);
            data.Write(player.TextureNum);
            data.Write(player.Level);
            data.Write(player.Map.GetID());
            data.Write(player.X);
            data.Write(player.Y);
            data.Write((byte)player.Direction);
            for (byte n = 0; n < (byte)Vitals.Count; n++)
            {
                data.Write(player.Vital[n]);
                data.Write(player.MaxVital(n));
            }
            for (byte n = 0; n < (byte)Attributes.Count; n++) data.Write(player.Attribute[n]);
            for (byte n = 0; n < (byte)Equipments.Count; n++) data.Write(player.Equipment[n].GetID());

            return data;
        }

        public static void Player_Position(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerPosition);
            data.Write(player.Name);
            data.Write(player.X);
            data.Write(player.Y);
            data.Write((byte)player.Direction);
            ToMap(player.Map, data);
        }

        public static void Player_Vitals(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerVitals);
            data.Write(player.Name);
            for (byte i = 0; i < (byte)Vitals.Count; i++)
            {
                data.Write(player.Vital[i]);
                data.Write(player.MaxVital(i));
            }

            ToMap(player.Map, data);
        }

        public static void Player_Leave(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerLeave);
            data.Write(player.Name);
            ToAllBut(player, data);
        }

        public static void Player_Move(Player player, byte movement)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerMove);
            data.Write(player.Name);
            data.Write(player.X);
            data.Write(player.Y);
            data.Write((byte)player.Direction);
            data.Write(movement);
            ToMapBut(player.Map, player, data);
        }

        public static void Player_Direction(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerDirection);
            data.Write(player.Name);
            data.Write((byte)player.Direction);
            ToMapBut(player.Map, player, data);
        }

        public static void Player_Experience(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerExperience);
            data.Write(player.Experience);
            data.Write(player.ExpNeeded);
            data.Write(player.Points);
            ToPlayer(player, data);
        }

        public static void Player_Equipments(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerEquipments);
            data.Write(player.Name);
            for (byte i = 0; i < (byte)Equipments.Count; i++) data.Write(player.Equipment[i].GetID());
            ToMap(player.Map, data);
        }

        public static void Map_Players(Player player)
        {
            // Envia os dados dos outros jogadores 
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (player != Account.List[i].Character)
                        if (Account.List[i].Character.Map == player.Map)
                            ToPlayer(player, Player_Data_Cache(Account.List[i].Character));

            // Envia os dados do jogador
            ToMap(player.Map, Player_Data_Cache(player));
        }

        public static void JoinMap(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.JoinMap);
            ToPlayer(player, data);
        }

        public static void Player_LeaveMap(Player player, TempMap map)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerLeave);
            data.Write(player.Name);
            ToMapBut(map, player, data);
        }

        public static void Map_Revision(Player player, Map map)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapRevision);
            data.Write(map.GetID());
            data.Write(map.Revision);
            ToPlayer(player, data);
        }

        public static void Maps(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerEditor.Maps);
            data.Write((short)CryBits.Entities.Map.List.Count);
            ToPlayer(account, data);
            foreach (Map map in CryBits.Entities.Map.List.Values) Map(account, map);
        }

        public static void Map(Account account, Map map)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.Map);
            else data.Write((byte)ServerClient.Map);
            ObjectToByteArray(data, map);
            ToPlayer(account, data);
        }

        public static void Latency(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.Latency);
            ToPlayer(account, data);
        }

        public static void Message(Player player, string text, Color color)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.Message);
            data.Write(text);
            data.Write(color.ToArgb());
            ToPlayer(player, data);
        }

        public static void Message_Map(Player player, string text)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();
            string message = "[Map] " + player.Name + ": " + text;

            // Envia os dados
            data.Write((byte)ServerClient.Message);
            data.Write(message);
            data.Write(Color.White.ToArgb());
            ToMap(player.Map, data);
        }

        public static void Message_Global(Player player, string text)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();
            string message = "[Global] " + player.Name + ": " + text;

            // Envia os dados
            data.Write((byte)ServerClient.Message);
            data.Write(message);
            data.Write(Color.Yellow.ToArgb());
            ToAll(data);
        }

        public static void Message_Private(Player player, string addresseeName, string text)
        {
            Player addressee = Player.Find(addresseeName);

            // Verifica se o jogador está conectado
            if (addressee == null)
            {
                Message(player, addresseeName + " is currently offline.", Color.Blue);
                return;
            }

            // Envia as mensagens
            Message(player, "[To] " + addresseeName + ": " + text, Color.Pink);
            Message(addressee, "[From] " + player.Name + ": " + text, Color.Pink);
        }

        public static void Player_Attack(Player player, string victim = "", Targets victimType = 0)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerAttack);
            data.Write(player.Name);
            data.Write(victim);
            data.Write((byte)victimType);
            ToMap(player.Map, data);
        }

        public static void Items(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.Items);
            else data.Write((byte)ServerClient.Items);
            ObjectToByteArray(data, Item.List);
            ToPlayer(account, data);
        }

        public static void Map_Items(Player player, TempMap map)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapItems);
            data.Write((byte)map.Item.Count);

            for (byte i = 0; i < map.Item.Count; i++)
            {
                // Geral
                data.Write(map.Item[i].Item.GetID());
                data.Write(map.Item[i].X);
                data.Write(map.Item[i].Y);
            }

            // Envia os dados
            ToPlayer(player, data);
        }

        public static void Map_Items(TempMap map)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapItems);
            data.Write((byte)map.Item.Count);
            for (byte i = 0; i < map.Item.Count; i++)
            {
                data.Write(map.Item[i].Item.GetID());
                data.Write(map.Item[i].X);
                data.Write(map.Item[i].Y);
            }
            ToMap(map, data);
        }

        public static void Player_Inventory(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerInventory);
            for (byte i = 0; i < MaxInventory; i++)
            {
                data.Write(player.Inventory[i].Item.GetID());
                data.Write(player.Inventory[i].Amount);
            }
            ToPlayer(player, data);
        }

        public static void Player_Hotbar(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PlayerHotbar);
            for (byte i = 0; i < MaxHotbar; i++)
            {
                data.Write((byte)player.Hotbar[i].Type);
                data.Write(player.Hotbar[i].Slot);
            }
            ToPlayer(player, data);
        }

        public static void NPCs(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.NPCs);
            else data.Write((byte)ServerClient.NPCs);
            ObjectToByteArray(data, NPC.List);
            ToPlayer(account, data);
        }

        public static void Map_NPCs(Player player, TempMap map)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPCs);
            data.Write((short)map.NPC.Length);
            for (byte i = 0; i < map.NPC.Length; i++)
            {
                data.Write(map.NPC[i].Data.GetID());
                data.Write(map.NPC[i].X);
                data.Write(map.NPC[i].Y);
                data.Write((byte)map.NPC[i].Direction);
                for (byte n = 0; n < (byte)Vitals.Count; n++) data.Write(map.NPC[i].Vital[n]);
            }
            ToPlayer(player, data);
        }

        public static void Map_NPC(TempNPC npc)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPC);
            data.Write(npc.Index);
            data.Write(npc.Data.GetID());
            data.Write(npc.X);
            data.Write(npc.Y);
            data.Write((byte)npc.Direction);
            for (byte n = 0; n < (byte)Vitals.Count; n++) data.Write(npc.Vital[n]);
            ToMap(npc.Map, data);
        }

        public static void Map_NPC_Movement(TempNPC npc, byte movement)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPCMovement);
            data.Write(npc.Index);
            data.Write(npc.X);
            data.Write(npc.Y);
            data.Write((byte)npc.Direction);
            data.Write(movement);
            ToMap(npc.Map, data);
        }

        public static void Map_NPC_Direction(TempNPC npc)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPCDirection);
            data.Write(npc.Index);
            data.Write((byte)npc.Direction);
            ToMap(npc.Map, data);
        }

        public static void Map_NPC_Vitals(TempNPC npc)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPCVitals);
            data.Write(npc.Index);
            for (byte n = 0; n < (byte)Vitals.Count; n++) data.Write(npc.Vital[n]);
            ToMap(npc.Map, data);
        }

        public static void Map_NPC_Attack(TempNPC npc, string victim = "", Targets victimType = 0)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPCAttack);
            data.Write(npc.Index);
            data.Write(victim);
            data.Write((byte)victimType);
            ToMap(npc.Map, data);
        }

        public static void Map_NPC_Died(TempNPC npc)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.MapNPCDied);
            data.Write(npc.Index);
            ToMap(npc.Map, data);
        }

        public static void Server_Data(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerEditor.ServerData);
            data.Write(GameName);
            data.Write(WelcomeMessage);
            data.Write(Port);
            data.Write(MaxPlayers);
            data.Write(MaxCharacters);
            data.Write(MaxPartyMembers);
            data.Write(MaxMapItems);
            data.Write(NumPoints);
            data.Write(MinNameLength);
            data.Write(MaxNameLength);
            data.Write(MinPasswordLength);
            data.Write(MaxPasswordLength);
            ToPlayer(account, data);
        }

        public static void Party(Player player)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.Party);
            data.Write((byte)player.Party.Count);
            for (byte i = 0; i < player.Party.Count; i++) data.Write(player.Party[i].Name);
            ToPlayer(player, data);
        }

        public static void Party_Invitation(Player player, string playerInvitation)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.PartyInvitation);
            data.Write(playerInvitation);
            ToPlayer(player, data);
        }

        public static void Trade(Player player, bool state)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.Trade);
            data.Write(state);
            ToPlayer(player, data);
        }

        public static void Trade_Invitation(Player player, string playerInvitation)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.TradeInvitation);
            data.Write(playerInvitation);
            ToPlayer(player, data);
        }

        public static void Trade_State(Player player, TradeStatus state)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.TradeState);
            data.Write((byte)state);
            ToPlayer(player, data);
        }

        public static void Trade_Offer(Player player, bool own = true)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();
            Player to = own ? player : player.Trade;

            // Envia os dados
            data.Write((byte)ServerClient.TradeOffer);
            data.Write(own);
            for (byte i = 0; i < MaxInventory; i++)
            {
                data.Write(to.Inventory[to.TradeOffer[i].SlotNum].Item.GetID());
                data.Write(to.TradeOffer[i].Amount);
            }
            ToPlayer(player, data);
        }

        public static void Shops(Account account)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            if (account.InEditor) data.Write((byte)ServerEditor.Shops);
            else data.Write((byte)ServerClient.Shops);
            ObjectToByteArray(data, Shop.List);
            ToPlayer(account, data);
        }

        public static void Shop_Open(Player player, Shop shop)
        {
            NetOutgoingMessage data = Socket.Device.CreateMessage();

            // Envia os dados
            data.Write((byte)ServerClient.ShopOpen);
            data.Write(shop.GetID());
            ToPlayer(player, data);
        }
    }
}
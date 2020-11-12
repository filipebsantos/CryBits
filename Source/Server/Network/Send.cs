﻿using CryBits.Server.Entities;
using CryBits.Packets;
using CryBits.Entities;
using Lidgren.Network;
using System.Drawing;
using static CryBits.Server.Logic.Utils;

namespace CryBits.Server.Network
{
    static class Send
    {
        private static void ToPlayer(Account Account, NetOutgoingMessage Data)
        {
            // Recria o pacote e o envia
            NetOutgoingMessage Data_Send = Socket.Device.CreateMessage(Data.LengthBytes);
            Data_Send.Write(Data);
            Socket.Device.SendMessage(Data_Send, Account.Connection, NetDeliveryMethod.ReliableOrdered);
        }

        private static void ToPlayer(Player Player, NetOutgoingMessage Data)
        {
            ToPlayer(Player.Account, Data);
        }

        private static void ToAll(NetOutgoingMessage Data)
        {
            // Envia os dados para todos conectados
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    ToPlayer(Account.List[i].Character, Data);
        }

        private static void ToAllBut(Player Player, NetOutgoingMessage Data)
        {
            // Envia os dados para todos conectados, com excessão do índice
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (Player != Account.List[i].Character)
                        ToPlayer(Account.List[i].Character, Data);
        }

        private static void ToMap(TempMap Map, NetOutgoingMessage Data)
        {
            // Envia os dados para todos conectados, com excessão do índice
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (Account.List[i].Character.Map == Map)
                        ToPlayer(Account.List[i].Character, Data);
        }

        private static void ToMapBut(TempMap Map, Player Player, NetOutgoingMessage Data)
        {
            // Envia os dados para todos conectados, com excessão do índice
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (Account.List[i].Character.Map == Map)
                        if (Player != Account.List[i].Character)
                            ToPlayer(Account.List[i].Character, Data);
        }

        public static void Alert(Account Account, string Message, bool Disconnect = true)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.Alert);
            else Data.Write((byte)ServerClient.Alert);
            Data.Write(Message);
            ToPlayer(Account, Data);

            // Desconecta o jogador
            if (Disconnect) Account.Connection.Disconnect(string.Empty);
        }

        public static void Connect(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.Connect);
            else Data.Write((byte)ServerClient.Connect);
            ToPlayer(Account, Data);
        }

        public static void CreateCharacter(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.CreateCharacter);
            ToPlayer(Account, Data);
        }

        public static void Join(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Join);
            Data.Write(Player.Name);
            ToPlayer(Player, Data);
        }

        public static void Characters(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Characters);
            Data.Write((byte)Account.Characters.Count);

            for (byte i = 0; i < Account.Characters.Count; i++)
            {
                Data.Write(Account.Characters[i].Name);
                Data.Write(Account.Characters[i].Texture_Num);
                Data.Write(Account.Characters[i].Level);
            }

            ToPlayer(Account, Data);
        }

        public static void Classes(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.Classes);
            else Data.Write((byte)ServerClient.Classes);
            Data.Write((byte)Class.List.Count);

            foreach (Class Class in Class.List.Values)
            {
                // Escreve os dados
                Data.Write(Class.ID.ToString());
                Data.Write(Class.Name);
                Data.Write(Class.Description);
                Data.Write((byte)Class.Tex_Male.Length);
                for (byte t = 0; t < Class.Tex_Male.Length; t++) Data.Write(Class.Tex_Male[t]);
                Data.Write((byte)Class.Tex_Female.Length);
                for (byte t = 0; t < Class.Tex_Female.Length; t++) Data.Write(Class.Tex_Female[t]);

                // Apenas dados do editor
                if (Account.InEditor)
                {
                    Data.Write(Class.Spawn_Map.GetID());
                    Data.Write(Class.Spawn_Direction);
                    Data.Write(Class.Spawn_X);
                    Data.Write(Class.Spawn_Y);
                    for (byte n = 0; n < (byte)Vitals.Count; n++) Data.Write(Class.Vital[n]);
                    for (byte n = 0; n < (byte)Attributes.Count; n++) Data.Write(Class.Attribute[n]);
                    Data.Write((byte)Class.Item.Length);
                    for (byte n = 0; n < (byte)Class.Item.Length; n++)
                    {
                        Data.Write(Class.Item[n].Item1.GetID());
                        Data.Write(Class.Item[n].Item2);
                    }
                }
            }

            // Envia os dados
            ToPlayer(Account, Data);
        }

        public static void JoinGame(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.JoinGame);
            ToPlayer(Player, Data);
        }

        public static NetOutgoingMessage Player_Data_Cache(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Escreve os dados
            Data.Write((byte)ServerClient.Player_Data);
            Data.Write(Player.Name);
            Data.Write(Player.Texture_Num);
            Data.Write(Player.Level);
            Data.Write(Player.Map.GetID());
            Data.Write(Player.X);
            Data.Write(Player.Y);
            Data.Write((byte)Player.Direction);
            for (byte n = 0; n < (byte)Vitals.Count; n++)
            {
                Data.Write(Player.Vital[n]);
                Data.Write(Player.MaxVital(n));
            }
            for (byte n = 0; n < (byte)Attributes.Count; n++) Data.Write(Player.Attribute[n]);
            for (byte n = 0; n < (byte)Equipments.Count; n++) Data.Write(Player.Equipment[n].GetID());

            return Data;
        }

        public static void Player_Position(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Position);
            Data.Write(Player.Name);
            Data.Write(Player.X);
            Data.Write(Player.Y);
            Data.Write((byte)Player.Direction);
            ToMap(Player.Map, Data);
        }

        public static void Player_Vitals(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Vitals);
            Data.Write(Player.Name);
            for (byte i = 0; i < (byte)Vitals.Count; i++)
            {
                Data.Write(Player.Vital[i]);
                Data.Write(Player.MaxVital(i));
            }

            ToMap(Player.Map, Data);
        }

        public static void Player_Leave(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Leave);
            Data.Write(Player.Name);
            ToAllBut(Player, Data);
        }

        public static void Player_Move(Player Player, byte Movement)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Move);
            Data.Write(Player.Name);
            Data.Write(Player.X);
            Data.Write(Player.Y);
            Data.Write((byte)Player.Direction);
            Data.Write(Movement);
            ToMapBut(Player.Map, Player, Data);
        }

        public static void Player_Direction(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Direction);
            Data.Write(Player.Name);
            Data.Write((byte)Player.Direction);
            ToMapBut(Player.Map, Player, Data);
        }

        public static void Player_Experience(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Experience);
            Data.Write(Player.Experience);
            Data.Write(Player.ExpNeeded);
            Data.Write(Player.Points);
            ToPlayer(Player, Data);
        }

        public static void Player_Equipments(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Equipments);
            Data.Write(Player.Name);
            for (byte i = 0; i < (byte)Equipments.Count; i++) Data.Write(Player.Equipment[i].GetID());
            ToMap(Player.Map, Data);
        }

        public static void Map_Players(Player Player)
        {
            // Envia os dados dos outros jogadores 
            for (byte i = 0; i < Account.List.Count; i++)
                if (Account.List[i].IsPlaying)
                    if (Player != Account.List[i].Character)
                        if (Account.List[i].Character.Map == Player.Map)
                            ToPlayer(Player, Player_Data_Cache(Account.List[i].Character));

            // Envia os dados do jogador
            ToMap(Player.Map, Player_Data_Cache(Player));
        }

        public static void JoinMap(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.JoinMap);
            ToPlayer(Player, Data);
        }

        public static void Player_LeaveMap(Player Player, TempMap Map)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Leave);
            Data.Write(Player.Name);
            ToMapBut(Map, Player, Data);
        }

        public static void Map_Revision(Player Player, Map Map)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_Revision);
            Data.Write(Map.GetID());
            Data.Write(Map.Revision);
            ToPlayer(Player, Data);
        }

        public static void Maps(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerEditor.Maps);
            Data.Write((short)CryBits.Entities.Map.List.Count);
            ToPlayer(Account, Data);
            foreach (Map Map in CryBits.Entities.Map.List.Values) Send.Map(Account, Map);
        }

        public static void Map(Account Account, Map Map)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.Map);
            else Data.Write((byte)ServerClient.Map);
            Data.Write(Map.GetID());
            Data.Write(Map.Revision);
            Data.Write(Map.Name);
            Data.Write(Map.Moral);
            Data.Write(Map.Panorama);
            Data.Write(Map.Music);
            Data.Write(Map.Color);
            Data.Write(Map.Weather.Type);
            Data.Write(Map.Weather.Intensity);
            Data.Write(Map.Fog.Texture);
            Data.Write(Map.Fog.Speed_X);
            Data.Write(Map.Fog.Speed_Y);
            Data.Write(Map.Fog.Alpha);
            Data.Write(Map.Lighting);

            // Ligações
            for (short i = 0; i < (short)Directions.Count; i++)
                Data.Write(Map.Link[i].GetID());

            // Camadas
            Data.Write((byte)Map.Layer.Length);
            for (byte i = 0; i < Map.Layer.Length; i++)
            {
                Data.Write(Map.Layer[i].Name);
                Data.Write(Map.Layer[i].Type);

                // Azulejos
                for (byte x = 0; x < Map.Width; x++)
                    for (byte y = 0; y < Map.Height; y++)
                    {
                        Data.Write(Map.Layer[i].Tile[x, y].X);
                        Data.Write(Map.Layer[i].Tile[x, y].Y);
                        Data.Write(Map.Layer[i].Tile[x, y].Tile);
                        Data.Write(Map.Layer[i].Tile[x, y].Auto);
                    }
            }

            // Dados específicos dos azulejos
            for (byte x = 0; x < Map.Width; x++)
                for (byte y = 0; y < Map.Height; y++)
                {
                    Data.Write(Map.Attribute[x, y].Type);
                    Data.Write(Map.Attribute[x, y].Data_1);
                    Data.Write(Map.Attribute[x, y].Data_2);
                    Data.Write(Map.Attribute[x, y].Data_3);
                    Data.Write(Map.Attribute[x, y].Data_4);
                    Data.Write(Map.Attribute[x, y].Zone);

                    // Bloqueio direcional
                    for (byte i = 0; i < (byte)Directions.Count; i++)
                        Data.Write(Map.Attribute[x, y].Block[i]);
                }

            // Luzes
            Data.Write((byte)Map.Light.Length);
            for (byte i = 0; i < Map.Light.Length; i++)
            {
                Data.Write(Map.Light[i].X);
                Data.Write(Map.Light[i].Y);
                Data.Write(Map.Light[i].Width);
                Data.Write(Map.Light[i].Height);
            }

            // NPCs
            Data.Write((byte)Map.NPC.Length);
            for (byte i = 0; i < Map.NPC.Length; i++)
            {
                Data.Write(Map.NPC[i].NPC.GetID());
                Data.Write(Map.NPC[i].Zone);
                Data.Write(Map.NPC[i].Spawn);
                Data.Write(Map.NPC[i].X);
                Data.Write(Map.NPC[i].Y);
            }
            ToPlayer(Account, Data);
        }

        public static void Latency(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Latency);
            ToPlayer(Account, Data);
        }

        public static void Message(Player Player, string Text, Color Color)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Message);
            Data.Write(Text);
            Data.Write(Color.ToArgb());
            ToPlayer(Player, Data);
        }

        public static void Message_Map(Player Player, string Text)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();
            string Message = "[Map] " + Player.Name + ": " + Text;

            // Envia os dados
            Data.Write((byte)ServerClient.Message);
            Data.Write(Message);
            Data.Write(Color.White.ToArgb());
            ToMap(Player.Map, Data);
        }

        public static void Message_Global(Player Player, string Text)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();
            string Message = "[Global] " + Player.Name + ": " + Text;

            // Envia os dados
            Data.Write((byte)ServerClient.Message);
            Data.Write(Message);
            Data.Write(Color.Yellow.ToArgb());
            ToAll(Data);
        }

        public static void Message_Private(Player Player, string Addressee_Name, string Texto)
        {
            Player Addressee = Player.Find(Addressee_Name);

            // Verifica se o jogador está conectado
            if (Addressee == null)
            {
                Message(Player, Addressee_Name + " is currently offline.", Color.Blue);
                return;
            }

            // Envia as mensagens
            Message(Player, "[To] " + Addressee_Name + ": " + Texto, Color.Pink);
            Message(Addressee, "[From] " + Player.Name + ": " + Texto, Color.Pink);
        }

        public static void Player_Attack(Player Player, string Victim = "", Targets Victim_Type = 0)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Attack);
            Data.Write(Player.Name);
            Data.Write(Victim);
            Data.Write((byte)Victim_Type);
            ToMap(Player.Map, Data);
        }

        public static void Items(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.Items);
            else Data.Write((byte)ServerClient.Items);
            Data.Write((short)Item.List.Count);
            foreach (Item Item in Item.List.Values)
            {
                Data.Write(Item.ID.ToString());
                Data.Write(Item.Name);
                Data.Write(Item.Description);
                Data.Write(Item.Texture);
                Data.Write((byte)Item.Type);
                Data.Write(Item.Stackable);
                Data.Write((byte)Item.Bind);
                Data.Write((byte)Item.Rarity);
                Data.Write(Item.Req_Level);
                Data.Write(Item.Req_Class.GetID());
                Data.Write(Item.Potion_Experience);
                for (byte v = 0; v < (byte)Vitals.Count; v++) Data.Write(Item.Potion_Vital[v]);
                Data.Write(Item.Equip_Type);
                for (byte a = 0; a < (byte)Attributes.Count; a++) Data.Write(Item.Equip_Attribute[a]);
                Data.Write(Item.Weapon_Damage);
            }

            // Envia os dados
            ToPlayer(Account, Data);
        }

        public static void Map_Items(Player Player, TempMap Map)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_Items);
            Data.Write((byte)Map.Item.Count);

            for (byte i = 0; i < Map.Item.Count; i++)
            {
                // Geral
                Data.Write(Map.Item[i].Item.GetID());
                Data.Write(Map.Item[i].X);
                Data.Write(Map.Item[i].Y);
            }

            // Envia os dados
            ToPlayer(Player, Data);
        }

        public static void Map_Items(TempMap Map)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_Items);
            Data.Write((byte)Map.Item.Count);
            for (byte i = 0; i < Map.Item.Count; i++)
            {
                Data.Write(Map.Item[i].Item.GetID());
                Data.Write(Map.Item[i].X);
                Data.Write(Map.Item[i].Y);
            }
            ToMap(Map, Data);
        }

        public static void Player_Inventory(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Inventory);
            for (byte i = 1; i <= Max_Inventory; i++)
            {
                Data.Write(Player.Inventory[i].Item.GetID());
                Data.Write(Player.Inventory[i].Amount);
            }
            ToPlayer(Player, Data);
        }

        public static void Player_Hotbar(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Player_Hotbar);
            for (byte i = 0; i < Max_Hotbar; i++)
            {
                Data.Write((byte)Player.Hotbar[i].Type);
                Data.Write(Player.Hotbar[i].Slot);
            }
            ToPlayer(Player, Data);
        }

        public static void NPCs(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.NPCs);
            else Data.Write((byte)ServerClient.NPCs);
            Data.Write((short)NPC.List.Count);
            foreach (NPC NPC in NPC.List.Values)
            {
                // Geral
                Data.Write(NPC.ID.ToString());
                Data.Write(NPC.Name);
                Data.Write(NPC.SayMsg);
                Data.Write(NPC.Texture);
                Data.Write((byte)NPC.Behaviour);
                for (byte n = 0; n < (byte)Vitals.Count; n++) Data.Write(NPC.Vital[n]);

                // Dados apenas do editor
                if (Account.InEditor)
                {
                    Data.Write(NPC.SpawnTime);
                    Data.Write(NPC.Sight);
                    Data.Write(NPC.Experience);
                    for (byte n = 0; n < (byte)Attributes.Count; n++) Data.Write(NPC.Attribute[n]);
                    Data.Write((byte)NPC.Drop.Length);
                    for (byte n = 0; n < NPC.Drop.Length; n++)
                    {
                        Data.Write(NPC.Drop[n].Item.GetID());
                        Data.Write(NPC.Drop[n].Amount);
                        Data.Write(NPC.Drop[n].Chance);
                    }
                    Data.Write(NPC.AttackNPC);
                    Data.Write((byte)NPC.Allie.Length);
                    for (byte n = 0; n < NPC.Allie.Length; n++) Data.Write(NPC.Allie[n].GetID());
                    Data.Write((byte)NPC.Movement);
                    Data.Write(NPC.Flee_Helth);
                    Data.Write(NPC.Shop.GetID());
                }
            }
            ToPlayer(Account, Data);
        }

        public static void Map_NPCs(Player Player, TempMap Map)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPCs);
            Data.Write((short)Map.NPC.Length);
            for (byte i = 0; i < Map.NPC.Length; i++)
            {
                Data.Write(Map.NPC[i].Data.GetID());
                Data.Write(Map.NPC[i].X);
                Data.Write(Map.NPC[i].Y);
                Data.Write((byte)Map.NPC[i].Direction);
                for (byte n = 0; n < (byte)Vitals.Count; n++) Data.Write(Map.NPC[i].Vital[n]);
            }
            ToPlayer(Player, Data);
        }

        public static void Map_NPC(TempNPC NPC)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPC);
            Data.Write(NPC.Index);
            Data.Write(NPC.Data.GetID());
            Data.Write(NPC.X);
            Data.Write(NPC.Y);
            Data.Write((byte)NPC.Direction);
            for (byte n = 0; n < (byte)Vitals.Count; n++) Data.Write(NPC.Vital[n]);
            ToMap(NPC.Map, Data);
        }

        public static void Map_NPC_Movement(TempNPC NPC, byte Movement)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPC_Movement);
            Data.Write(NPC.Index);
            Data.Write(NPC.X);
            Data.Write(NPC.Y);
            Data.Write((byte)NPC.Direction);
            Data.Write(Movement);
            ToMap(NPC.Map, Data);
        }

        public static void Map_NPC_Direction(TempNPC NPC)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPC_Direction);
            Data.Write(NPC.Index);
            Data.Write((byte)NPC.Direction);
            ToMap(NPC.Map, Data);
        }

        public static void Map_NPC_Vitals(TempNPC NPC)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPC_Vitals);
            Data.Write(NPC.Index);
            for (byte n = 0; n < (byte)Vitals.Count; n++) Data.Write(NPC.Vital[n]);
            ToMap(NPC.Map, Data);
        }

        public static void Map_NPC_Attack(TempNPC NPC, string Victim = "", Targets Victim_Type = 0)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPC_Attack);
            Data.Write(NPC.Index);
            Data.Write(Victim);
            Data.Write((byte)Victim_Type);
            ToMap(NPC.Map, Data);
        }

        public static void Map_NPC_Died(TempNPC NPC)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Map_NPC_Died);
            Data.Write(NPC.Index);
            ToMap(NPC.Map, Data);
        }

        public static void Server_Data(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerEditor.Server_Data);
            Data.Write(Game_Name);
            Data.Write(Welcome_Message);
            Data.Write(Port);
            Data.Write(Max_Players);
            Data.Write(Max_Characters);
            Data.Write(Max_Party_Members);
            Data.Write(Max_Map_Items);
            Data.Write(Num_Points);
            Data.Write(Min_Name_Length);
            Data.Write(Max_Name_Length);
            Data.Write(Min_Password_Length);
            Data.Write(Max_Password_Length);
            ToPlayer(Account, Data);
        }

        public static void Party(Player Player)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Party);
            Data.Write((byte)Player.Party.Count);
            for (byte i = 0; i < Player.Party.Count; i++) Data.Write(Player.Party[i].Name);
            ToPlayer(Player, Data);
        }

        public static void Party_Invitation(Player Player, string Player_Invitation)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Party_Invitation);
            Data.Write(Player_Invitation);
            ToPlayer(Player, Data);
        }

        public static void Trade(Player Player, bool State)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Trade);
            Data.Write(State);
            ToPlayer(Player, Data);
        }

        public static void Trade_Invitation(Player Player, string Player_Invitation)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Trade_Invitation);
            Data.Write(Player_Invitation);
            ToPlayer(Player, Data);
        }

        public static void Trade_State(Player Player, TradeStatus State)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Trade_State);
            Data.Write((byte)State);
            ToPlayer(Player, Data);
        }

        public static void Trade_Offer(Player Player, bool Own = true)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();
            Player To = Own ? Player : Player.Trade;

            // Envia os dados
            Data.Write((byte)ServerClient.Trade_Offer);
            Data.Write(Own);
            for (byte i = 1; i <= Max_Inventory; i++)
            {
                Data.Write(To.Inventory[To.Trade_Offer[i].Slot_Num].Item.GetID());
                Data.Write(To.Trade_Offer[i].Amount);
            }
            ToPlayer(Player, Data);
        }

        public static void Shops(Account Account)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            if (Account.InEditor) Data.Write((byte)ServerEditor.Shops);
            else Data.Write((byte)ServerClient.Shops);
            Data.Write((short)Shop.List.Count);
            foreach (Shop Shop in Shop.List.Values)
            {
                // Geral
                Data.Write(Shop.ID.ToString());
                Data.Write(Shop.Name);
                Data.Write(Shop.Currency.GetID());
                Data.Write((byte)Shop.Sold.Length);
                for (byte j = 0; j < Shop.Sold.Length; j++)
                {
                    Data.Write(Shop.Sold[j].Item.GetID());
                    Data.Write(Shop.Sold[j].Amount);
                    Data.Write(Shop.Sold[j].Price);
                }
                Data.Write((byte)Shop.Bought.Length);
                for (byte j = 0; j < Shop.Bought.Length; j++)
                {
                    Data.Write(Shop.Bought[j].Item.GetID());
                    Data.Write(Shop.Bought[j].Amount);
                    Data.Write(Shop.Bought[j].Price);
                }
            }
            ToPlayer(Account, Data);
        }

        public static void Shop_Open(Player Player, Shop Shop)
        {
            NetOutgoingMessage Data = Socket.Device.CreateMessage();

            // Envia os dados
            Data.Write((byte)ServerClient.Shop_Open);
            Data.Write(Shop.GetID());
            ToPlayer(Player, Data);
        }
    }
}
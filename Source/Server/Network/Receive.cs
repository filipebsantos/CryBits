﻿using Lidgren.Network;
using System.IO;

class Receive
{
    // Pacotes do cliente
    public enum Packets
    {
        Latency,
        Connect,
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
        Hotbar_Use
    }

    public static void Handle(byte Index, NetIncomingMessage Data)
    {
        // Manuseia os dados recebidos
        switch ((Packets)Data.ReadByte())
        {
            case Packets.Latency: Latency(Index); break;
            case Packets.Connect: Connect(Index, Data); break;
            case Packets.Register: Register(Index, Data); break;
            case Packets.CreateCharacter: CreateCharacter(Index, Data); break;
            case Packets.Character_Use: Character_Use(Index, Data); break;
            case Packets.Character_Create: Character_Create(Index); break;
            case Packets.Character_Delete: Character_Delete(Index, Data); break;
            case Packets.Player_Direction: Player_Direction(Index, Data); break;
            case Packets.Player_Move: Player_Move(Index, Data); break;
            case Packets.Player_Attack: Player_Attack(Index); break;
            case Packets.RequestMap: RequestMap(Index, Data); break;
            case Packets.Message: Message(Index, Data); break;
            case Packets.AddPoint: AddPoint(Index, Data); break;
            case Packets.CollectItem: CollectItem(Index); break;
            case Packets.DropItem: DropItem(Index, Data); break;
            case Packets.Inventory_Change: Inventory_Change(Index, Data); break;
            case Packets.Inventory_Use: Inventory_Use(Index, Data); break;
            case Packets.Equipment_Remove: Equipment_Remove(Index, Data); break;
            case Packets.Hotbar_Add: Hotbar_Add(Index, Data); break;
            case Packets.Hotbar_Change: Hotbar_Change(Index, Data); break;
            case Packets.Hotbar_Use: Hotbar_Use(Index, Data); break;
        }
    }

    private static void Latency(byte Index)
    {
        // Envia o pacote para a contagem da latência
        Send.Latency(Index);
    }

    private static void Connect(byte Index, NetIncomingMessage Data)
    {
        // Lê os dados
        string User = Data.ReadString().Trim();
        string Password = Data.ReadString();
        bool Editor = Data.ReadBoolean();

        // Verifica se está tudo certo
        if (!File.Exists(Directories.Accounts.FullName + User + Directories.Format))
        {
            Send.Alert(Index, "This username isn't registered.");
            return;
        }
        if (Player.MultipleAccounts(User))
        {
            Send.Alert(Index, "Someone already signed in to this account.");
            return;
        }
        if (Password != Read.Player_Password(User))
        {
            Send.Alert(Index, "Password is incorrect.");
            return;
        }

        if (Editor)
        {
            // Carrega somente os dados importantes do jogador
            Read.Player(Index, User, false);

            // Verifica se o jogador tem permissão para fazer entrar no modo edição
            if (Lists.Player[Index].Acess < Game.Accesses.Editor)
            {
                Clear.Player(Index);
                Send.Alert(Index, "You're not allowed to do this.");
                return;
            }

            // Abre a janela de edição
            Send.Connect(Index);
        }
        else
        {
            // Carrega os dados do jogador
            Read.Player(Index, User);

            // Envia os dados das classes
            Send.Classes(Index);

            // Se o jogador não tiver nenhum personagem então abrir o painel de criação de personagem
            if (!Player.HasCharacter(Index))
            {
                Send.CreateCharacter(Index);
                return;
            }

            // Abre a janela de seleção de personagens
            Send.Characters(Index);
            Send.Connect(Index);
        }
    }

    private static void Register(byte Index, NetIncomingMessage Data)
    {
        // Lê os dados
        string User = Data.ReadString().Trim();
        string Password = Data.ReadString();

        // Verifica se está tudo certo
        if (User.Length < Game.Min_Name_Length || User.Length > Game.Max_Name_Length || Password.Length < Game.Min_Name_Length || Password.Length > Game.Max_Name_Length)
        {
            Send.Alert(Index, "The username and password must contain between " + Game.Min_Name_Length + " and " + Game.Max_Name_Length + " characters.");
            return;
        }
        if (File.Exists(Directories.Accounts.FullName + User + Directories.Format))
        {
            Send.Alert(Index, "There is already someone registered with this name.");
            return;
        }

        // Cria a conta
        Lists.Player[Index].User = User;
        Lists.Player[Index].Password = Password;

        // Salva a conta
        Write.Player(Index);

        // Abre a janela de seleção de personagens
        Send.Classes(Index);
        Send.CreateCharacter(Index);
    }

    private static void CreateCharacter(byte Index, NetIncomingMessage Data)
    {
        byte Character = Player.FindCharacter(Index, string.Empty);

        // Lê os dados
        string Name = Data.ReadString().Trim();

        // Verifica se está tudo certo
        if (Name.Length < Game.Min_Name_Length || Name.Length > Game.Max_Name_Length)
        {
            Send.Alert(Index, "The character name must contain between " + Game.Min_Name_Length + " and " + Game.Max_Name_Length + " characters.", false);
            return;
        }
        if (Name.Contains(";") || Name.Contains(":"))
        {
            Send.Alert(Index, "Can't contain ';' and ':' in the character name.", false);
            return;
        }
        if (Read.Characters_Name().Contains(";" + Name + ":"))
        {
            Send.Alert(Index, "A character with this name already exists", false);
            return;
        }

        // Define o personagem que será usado
        Lists.TempPlayer[Index].Using = Character;

        // Define os valores iniciais do personagem
        Player.Character(Index).Name = Name;
        Player.Character(Index).Level = 1;
        Player.Character(Index).Class = Data.ReadByte();
        Player.Character(Index).Genre = Data.ReadBoolean();
        Player.Character(Index).Attribute = Lists.Class[Player.Character(Index).Class].Attribute;
        Player.Character(Index).Map = Lists.Class[Player.Character(Index).Class].Spawn_Map;
        Player.Character(Index).Direction = (Game.Directions)Lists.Class[Player.Character(Index).Class].Spawn_Direction;
        Player.Character(Index).X = Lists.Class[Player.Character(Index).Class].Spawn_X;
        Player.Character(Index).Y = Lists.Class[Player.Character(Index).Class].Spawn_Y;
        for (byte i = 0; i <= (byte)Game.Vitals.Amount - 1; i++) Player.Character(Index).Vital[i] = Player.Character(Index).MaxVital(i);

        // Salva a conta
        Write.Character(Name);
        Write.Player(Index);

        // Entra no jogo
        Player.Join(Index);
    }

    private static void Character_Use(byte Index, NetIncomingMessage Data)
    {
        // Define o personagem que será usado
        Lists.TempPlayer[Index].Using = Data.ReadByte();

        // Entra no jogo
        Player.Join(Index);
    }

    private static void Character_Create(byte Index)
    {
        // Verifica se o jogador já criou o máximo de personagens possíveis
        if (Player.FindCharacter(Index, string.Empty) == 0)
        {
            Send.Alert(Index, "You can only have " + Lists.Server_Data.Max_Characters + " characters.", false);
            return;
        }

        // Abre a janela de seleção de personagens
        Send.Classes(Index);
        Send.CreateCharacter(Index);
    }

    private static void Character_Delete(byte Index, NetIncomingMessage Data)
    {
        byte Character = Data.ReadByte();
        string Name = Lists.Player[Index].Character[Character].Name;

        // Verifica se o personagem existe
        if (string.IsNullOrEmpty(Name)) return;

        // Deleta o personagem
        Send.Alert(Index, "The character '" + Name + "' has been deleted.", false);
        Write.Characters(Read.Characters_Name().Replace(":;" + Name + ":", ":"));
        Clear.Player_Character(Index, Character);

        // Salva o personagem
        Send.Characters(Index);
        Write.Player(Index);
    }

    private static void Player_Direction(byte Index, NetIncomingMessage Data)
    {
        Game.Directions Direction = (Game.Directions)Data.ReadByte();

        // Previne erros
        if (Direction < Game.Directions.Up || Direction > Game.Directions.Right) return;
        if (Lists.TempPlayer[Index].GettingMap) return;

        // Defini a direção do jogador
        Player.Character(Index).Direction = Direction;
        Send.Player_Direction(Index);
    }

    private static void Player_Move(byte Index, NetIncomingMessage Data)
    {
        byte X = Data.ReadByte(), Y = Data.ReadByte();

        // Move o jogador se necessário
        if (Player.Character(Index).X != X || Player.Character(Index).Y != Y)
            Send.Player_Position(Index);
        else
            Player.Move(Index, Data.ReadByte());
    }

    private static void RequestMap(byte Index, NetIncomingMessage Data)
    {
        // Se necessário enviar as informações do mapa ao jogador
        if (Data.ReadBoolean()) Send.Map(Index, Player.Character(Index).Map);

        // Envia a informação aos outros jogadores
        Send.Map_Players(Index);

        // Entra no mapa
        Lists.TempPlayer[Index].GettingMap = false;
        Send.JoinMap(Index);
    }

    private static void Message(byte Index, NetIncomingMessage Data)
    {
        string Message = Data.ReadString();

        // Evita caracteres inválidos
        for (byte i = 0; i >= Message.Length; i++)
            if ((Message[i] < 32 && Message[i] > 126))
                return;

        // Envia a mensagem para os outros jogadores
        switch ((Game.Messages)Data.ReadByte())
        {
            case Game.Messages.Map: Send.Message_Map(Index, Message); break;
            case Game.Messages.Global: Send.Message_Global(Index, Message); break;
            case Game.Messages.Private: Send.Message_Private(Index, Data.ReadString(), Message); break;
        }
    }

    private static void Player_Attack(byte Index)
    {
        // Ataca
        Player.Attack(Index);
    }

    private static void AddPoint(byte Index, NetIncomingMessage Data)
    {
        byte Attribute_Num = Data.ReadByte();

        // Adiciona um ponto a determinado atributo
        if (Player.Character(Index).Points > 0)
        {
            Player.Character(Index).Attribute[Attribute_Num] += 1;
            Player.Character(Index).Points -= 1;
            Send.Player_Experience(Index);
            Send.Map_Players(Index);
        }
    }

    private static void CollectItem(byte Index)
    {
        short Map_Num = Player.Character(Index).Map;
        byte Map_Item = Map.HasItem(Map_Num, Player.Character(Index).X, Player.Character(Index).Y);
        short Map_Item_Num = Lists.Map[Map_Num].Temp_Item[Map_Item].Index;

        // Somente se necessário
        if (Map_Item == 0) return;

        // Dá o item ao jogador
        if (Player.GiveItem(Index, Map_Item_Num, Lists.Map[Map_Num].Temp_Item[Map_Item].Amount))
        {
            // Retira o item do mapa
            Lists.Map[Map_Num].Temp_Item.RemoveAt(Map_Item);
            Send.Map_Items(Map_Num);
        }
    }

    private static void DropItem(byte Index, NetIncomingMessage Data)
    {
        Player.DropItem(Index, Data.ReadByte());
    }

    private static void Inventory_Change(byte Index, NetIncomingMessage Data)
    {
        byte Slot_Old = Data.ReadByte(), Slot_New = Data.ReadByte();
        byte Hotbar_Old = Player.FindHotbar(Index, (byte)Game.Hotbar.Item, Slot_Old), Hotbar_New = Player.FindHotbar(Index, (byte)Game.Hotbar.Item, Slot_New);
        Lists.Structures.Inventories Old = Player.Character(Index).Inventory[Slot_Old];

        // Somente se necessário
        if (Player.Character(Index).Inventory[Slot_Old].Item_Num == 0) return;
        if (Slot_Old == Slot_New) return;

        // Caso houver um item no novo slot, trocar ele para o velho
        if (Player.Character(Index).Inventory[Slot_New].Item_Num > 0)
        {
            // Inventário
            Player.Character(Index).Inventory[Slot_Old].Item_Num = Player.Character(Index).Inventory[Slot_New].Item_Num;
            Player.Character(Index).Inventory[Slot_Old].Amount = Player.Character(Index).Inventory[Slot_New].Amount;
            Player.Character(Index).Hotbar[Hotbar_New].Slot = Slot_Old;
        }
        else
        {
            Player.Character(Index).Inventory[Slot_Old].Item_Num = 0;
            Player.Character(Index).Inventory[Slot_Old].Amount = 0;
        }

        // Muda o item de slot
        Player.Character(Index).Inventory[Slot_New].Item_Num = Old.Item_Num;
        Player.Character(Index).Inventory[Slot_New].Amount = Old.Amount;
        Player.Character(Index).Hotbar[Hotbar_Old].Slot = Slot_New;
        Send.Player_Inventory(Index);
        Send.Player_Hotbar(Index);
    }

    private static void Inventory_Use(byte Index, NetIncomingMessage Data)
    {
        Player.UseItem(Index, Data.ReadByte());
    }

    private static void Equipment_Remove(byte Index, NetIncomingMessage Data)
    {
        byte Slot = Data.ReadByte();
        short Map_Num = Player.Character(Index).Map;
        Lists.Structures.Map_Items Map_Item = new Lists.Structures.Map_Items();

        // Apenas se necessário
        if (Player.Character(Index).Equipment[Slot] == 0) return;

        // Adiciona o equipamento ao inventário
        if (!Player.GiveItem(Index, Player.Character(Index).Equipment[Slot], 1))
        {
            // Somente se necessário
            if (Lists.Map[Map_Num].Temp_Item.Count == Game.Max_Map_Items) return;

            // Solta o item no chão
            Map_Item.Index = Player.Character(Index).Equipment[Slot];
            Map_Item.Amount = 1;
            Map_Item.X = Player.Character(Index).X;
            Map_Item.Y = Player.Character(Index).Y;
            Lists.Map[Map_Num].Temp_Item.Add(Map_Item);

            // Envia os dados
            Send.Map_Items(Map_Num);
            Send.Player_Inventory(Index);
        }

        // Remove o equipamento
        for (byte i = 0; i <= (byte)Game.Attributes.Amount - 1; i++) Player.Character(Index).Attribute[i] -= Lists.Item[Player.Character(Index).Equipment[Slot]].Equip_Attribute[i];
        Player.Character(Index).Equipment[Slot] = 0;

        // Envia os dados
        Send.Player_Equipments(Index);
    }

    private static void Hotbar_Add(byte Index, NetIncomingMessage Data)
    {
        byte Hotbar_Slot = Data.ReadByte();
        byte Type = Data.ReadByte();
        byte Slot = Data.ReadByte();

        // Somente se necessário
        if (Slot != 0 && Player.FindHotbar(Index, Type, Slot) > 0) return;

        // Define os dados
        Player.Character(Index).Hotbar[Hotbar_Slot].Slot = Slot;
        Player.Character(Index).Hotbar[Hotbar_Slot].Type = Type;

        // Envia os dados
        Send.Player_Hotbar(Index);
    }

    private static void Hotbar_Change(byte Index, NetIncomingMessage Data)
    {
        byte Slot_Old = Data.ReadByte(), Slot_New = Data.ReadByte();
        Lists.Structures.Hotbar Old = Player.Character(Index).Hotbar[Slot_Old];

        // Somente se necessário
        if (Player.Character(Index).Hotbar[Slot_Old].Slot == 0) return;
        if (Slot_Old == Slot_New) return;

        // Caso houver um item no novo slot, trocar ele para o velho
        if (Player.Character(Index).Hotbar[Slot_New].Slot > 0)
        {
            Player.Character(Index).Hotbar[Slot_Old].Slot = Player.Character(Index).Hotbar[Slot_New].Slot;
            Player.Character(Index).Hotbar[Slot_Old].Type = Player.Character(Index).Hotbar[Slot_New].Type;
        }
        else
        {
            Player.Character(Index).Hotbar[Slot_Old].Slot = 0;
            Player.Character(Index).Hotbar[Slot_Old].Type = 0;
        }

        // Muda o item de slot
        Player.Character(Index).Hotbar[Slot_New].Slot = Old.Slot;
        Player.Character(Index).Hotbar[Slot_New].Type = Old.Type;
        Send.Player_Hotbar(Index);
    }

    private static void Hotbar_Use(byte Index, NetIncomingMessage Data)
    {
        byte Hotbar_Slot = Data.ReadByte();

        // Usa o item
        if (Player.Character(Index).Hotbar[Hotbar_Slot].Type == (byte)Game.Hotbar.Item)
            Player.UseItem(Index, Player.Character(Index).Hotbar[Hotbar_Slot].Slot);
    }
}
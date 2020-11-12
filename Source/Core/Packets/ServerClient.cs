﻿namespace CryBits.Packets
{
    // Pacotes do servidor para o cliente
    public enum ServerClient
    {
        Alert,
        Connect,
        CreateCharacter,
        Join,
        Classes,
        Characters,
        JoinGame,
        PlayerData,
        PlayerPosition,
        PlayerVitals,
        PlayerLeave,
        PlayerAttack,
        PlayerMove,
        PlayerDirection,
        PlayerExperience,
        PlayerInventory,
        PlayerEquipments,
        PlayerHotbar,
        JoinMap,
        MapRevision,
        Map,
        Latency,
        Message,
        NPCs,
        MapNPCs,
        MapNPC,
        MapNPCMovement,
        MapNPCDirection,
        MapNPCVitals,
        MapNPCAttack,
        MapNPCDied,
        Items,
        MapItems,
        Party,
        PartyInvitation,
        Trade,
        TradeInvitation,
        TradeState,
        TradeOffer,
        Shops,
        ShopOpen
    }
}

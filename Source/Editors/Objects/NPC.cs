﻿using System;
using System.ComponentModel;
using static Utils;

namespace Objects
{
    class NPC : Data
    {
        public string Name = string.Empty;
        public string SayMsg = string.Empty;
        public short Texture;
        public byte Behaviour;
        public byte SpawnTime;
        public byte Sight;
        public int Experience;
        public short[] Vital = new short[(byte)Vitals.Count];
        public short[] Attribute = new short[(byte)Attributes.Count];
        public BindingList<NPC_Drop> Drop = new BindingList<NPC_Drop>();
        public bool AttackNPC;
        public BindingList<NPC> Allie = new BindingList<NPC>();
        public NPC_Movements Movement;
        public byte Flee_Helth;
        public Shop Shop;

        public NPC(Guid ID) : base(ID) { }
        public override string ToString() => Name;
    }

    class NPC_Drop : Lists.Structures.Inventory
    {
        public byte Chance;

        public NPC_Drop(Item Item, short Amount, byte Chance) : base(Item, Amount)
        {
            this.Chance = Chance;
        }
        public override string ToString() => Item.Name + " [" + Amount + "x, " + Chance + "%]";
    }
}
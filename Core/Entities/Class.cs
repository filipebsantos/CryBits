﻿using System;
using System.Collections.Generic;

namespace CryBits.Entities
{
    [Serializable]
    public class Class : Entity
    {
        // Lista de dados
        public static Dictionary<Guid, Class> List = new();

        // Dados
        public string Description { get; set; }
        public IList<short> TexMale { get; set; } = new List<short>();
        public IList<short> TexFemale { get; set; } = new List<short>();
        public Map SpawnMap { get; set; }
        public byte SpawnDirection { get; set; }
        public byte SpawnX { get; set; }
        public byte SpawnY { get; set; }
        public short[] Vital { get; set; } = new short[(byte)Enums.Vital.Count];
        public short[] Attribute { get; set; } = new short[(byte)Enums.Attribute.Count];
        public IList<ItemSlot> Item { get; set; } = new List<ItemSlot>();
    }
}

﻿using CryBits.Entities;
using System;
using System.Collections.Generic;

namespace CryBits.Client.Entities
{
    class NPC : Entity
    {
        // Lista de dados
        public static Dictionary<Guid, NPC> List;

        // Obtém o dado, caso ele não existir retorna nulo
        public static NPC Get(Guid id) => List.ContainsKey(id) ? List[id] : null;

        // Dados gerais
        public string SayMsg;
        public short Texture;
        public byte Type;
        public short[] Vital = new short[(byte)Vitals.Count];

        public NPC(Guid id) : base(id) { }
    }
}

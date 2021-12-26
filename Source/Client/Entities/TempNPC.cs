﻿using System;
using CryBits.Entities;

namespace CryBits.Client.Entities
{
    internal class TempNPC : Character
    {
        // Indice
        public NPC Data;

        public void Logic()
        {
            // Dano
            if (Hurt + 325 < Environment.TickCount) Hurt = 0;

            // Movimento
            ProcessMovement();
        }
    }
}
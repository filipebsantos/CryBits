﻿using System;
using CryBits.Entities.Npc;

namespace CryBits.Client.Entities;

internal class TempNpc : Character
{
    public Npc Data { get; set; }

    public void Logic()
    {
        // Dano
        if (Hurt + 325 < Environment.TickCount) Hurt = 0;

        // Movimento
        ProcessMovement();
    }
}
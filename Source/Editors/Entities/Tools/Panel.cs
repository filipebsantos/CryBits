﻿namespace CryBits.Editors.Entities.Tools
{
    class Panel : Tool
    {
        public byte Texture_Num { get; set; }

        public override string ToString() => "[Panel] " + Name;
    }
}

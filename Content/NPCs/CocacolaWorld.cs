using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CocacolaMan.Content.NPCs
{
    public class CocacolaWorld : ModSystem
    {
        public static bool CocacolamanUnlocked = false;

        public override void OnWorldLoad()
        {
            CocacolamanUnlocked = false;
        }

        public override void OnWorldUnload()
        {
            CocacolamanUnlocked = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (CocacolamanUnlocked)
            {
                tag["CocacolamanUnlocked"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            CocacolamanUnlocked = tag.ContainsKey("CocacolamanUnlocked");
        }
    }
}
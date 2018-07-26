using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bananium.Tiles
{
    public class BananiumOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = 57;
            soundType = 21;
            soundStyle = 2;
            mineResist = 15f;
            minPick = 200;
            AddMapEntry(new Color(255, 255, 0));
            drop = mod.ItemType("BananiumOre");
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.3f;
            b = 0f;
        }
    }
}

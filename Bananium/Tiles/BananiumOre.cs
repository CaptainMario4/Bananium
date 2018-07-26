using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium.Tiles
{
    public class BananiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bananium Ore");
            Tooltip.SetDefault("Could this ore really exist in scientific terms?");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.melee = false;
            item.width = 12;
            item.height = 12;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;           
            item.value = 5000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("BananiumOreTile");
            item.maxStack = 999;
        }
    }
}

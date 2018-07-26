using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Bananium.Placeables
{
    public class BananaAnvil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Banana Anvil");
        }


        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.useTime = 14;
            item.useAnimation = 17;
            item.useTurn = true;
            item.autoReuse = true;
            item.useStyle = 1;
            item.createTile = mod.TileType("BananaAnvil");
            item.consumable = true;
        }
    }
}

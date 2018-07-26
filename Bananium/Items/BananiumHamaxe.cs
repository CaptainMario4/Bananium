using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium.Items
{
    public class BananiumHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Both a hammer and an axe combined into one, infused with Bananium.");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.axe = 70;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
            item.hammer = 150;      //How much hammer power the weapon has
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BananiumBar", 15);
            recipe.AddTile(null, "BananaAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

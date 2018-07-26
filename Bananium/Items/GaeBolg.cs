using System;
using Bananium.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium.Items
{
    public class GaeBolg : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Always aims for the heart, never missing it's target.");
        }

        public override void SetDefaults()
        {
            item.damage = 150;
            item.useStyle = 5;
            item.useAnimation = 18;
            item.useTime = 24;
            item.shootSpeed = 6f;
            item.knockBack = 7f;
            item.width = 40;
            item.height = 40;
            item.scale = 1.1f;
            item.rare = 8;
            item.value = Item.sellPrice(silver: 10);

            item.melee = true;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<Projectiles.GaeBolgProjectile>();

        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BananiumBar", 10);
            recipe.AddTile(null, "BananaAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}

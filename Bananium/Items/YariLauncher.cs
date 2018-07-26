using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium.Items
{
    public class YariLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Why fire one rocket when you can fire 6? Created by TunaCat.");
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.autoReuse = true;
            item.reuseDelay = 14;
            item.useAnimation = 12;
            item.useTime = 4;
            item.useAmmo = AmmoID.Rocket;
            item.crit = 50;
            item.width = 64;
            item.height = 24;
            item.shoot = ProjectileID.RocketSnowmanIII;
            item.UseSound = SoundID.Item11;
            item.damage = 50;
            item.shootSpeed = 5f;
            item.noMelee = true;
            item.value = 100000;
            item.knockBack = 4f;
            item.rare = 8;
            item.ranged = true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool ConsumeAmmo(Player player)
        {
            // Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (UseAmination - 1, then - useTime until less than 0.) 
            // We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
            return !(player.itemAnimation < item.useAnimation - 3);
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 20, 0))
            {
                position += muzzleOffset;
            }

            int numberProjectiles = 1 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
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
            recipe.AddIngredient(null, "BananiumBar", 20);
            recipe.AddTile(null, "BananaAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
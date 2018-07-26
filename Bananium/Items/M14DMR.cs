using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium.Items
{
	public class M14DMR : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A modern Semi-Automatic Sniper Rifle: Created by TunaCat.");
        }

        public override void SetDefaults()
        {
            item.damage = 300;
            item.crit = 50;
            item.ranged = true;
            item.width = 35;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 9;
            item.value = 10000;
            item.rare = 9;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = ProjectileID.GoldenBullet; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .70f;
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

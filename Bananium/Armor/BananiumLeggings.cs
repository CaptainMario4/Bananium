using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BananiumLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The power of Bananium coarses through your veins\nIncreases Critical Strike Chance and Reduce 10% of all incoming damage.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
            item.defense = 45;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("BananiumHelmet") && body.type == mod.ItemType("BananiumBreastplate");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.lifeRegen = +21;
            player.meleeDamage += 1;
            player.meleeCrit += 20;
            player.statDefense += 10;
            player.manaRegen += 20;
            player.lifeSteal += 20;
            player.armorPenetration += 25;
            player.endurance += 0.10f;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 3;
            player.buffImmune[BuffID.Confused] = true;
            player.AddBuff(BuffID.Rage, 60);
            player.AddBuff(BuffID.Endurance, 60);
            player.statLifeMax2 += 100;
            player.statManaMax2 += 100;
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
            recipe.AddIngredient(null, "BananiumBar", 12);
            recipe.AddTile(null, "BananaAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

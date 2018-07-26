using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Bananium.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BananiumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The power of Bananium coarses through your veins\nIncreases Melee Damage and Melee Knockback.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 8;
            item.defense = 50; // The Defence value for this piece of armour.
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("BananiumHelmet") && legs.type == mod.ItemType("BananiumLeggings");
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
            player.endurance += 0.15f;
        }
        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.Chilled] = true;
            player.AddBuff(BuffID.Wrath, 60);
            player.AddBuff(BuffID.Titan, 60);
            player.statManaMax2 += 40;
            player.statLifeMax2 += 100;
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
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(null, "BananiumBar", 15);
            r.AddTile(null, "BananaAnvil"); // Anvils = Iron, Lead, Mythril, etc
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
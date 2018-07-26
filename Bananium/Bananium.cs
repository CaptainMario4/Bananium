using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bananium
{
	class Bananium : Mod
	{
		public Bananium()
		{

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);    //this is an example of how to add an alternative recipe with RecipeGroup for nightsedge
            recipe = new ModRecipe(this);              //this is an example of how to add a recipe with modded items
            recipe.AddIngredient(null, "BananiumOre", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(null, "BananaAnvil", 1); //Sets the result of this recipe with the given vanilla item name and stack size.
            recipe.AddRecipe();
        }
    }
}

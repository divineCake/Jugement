using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Judgement.Items.Material
{
	public class NanestineBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nanestine Bar");
			Tooltip.SetDefault("It is pulsing with foul energy.");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.value = 1800;
			item.rare = 2;
			item.maxStack = 999;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronOre, 3);
			recipe.AddIngredient(mod.ItemType("NanestineOre"));
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe (mod);
			recipe.AddIngredient(ItemID.LeadOre, 3);
			recipe.AddIngredient(mod.ItemType("NanestineOre"));
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
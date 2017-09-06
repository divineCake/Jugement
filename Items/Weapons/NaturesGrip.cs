using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Judgement.Items.Weapons
{
	public class NaturesGrip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature''s Grip");
			Tooltip.SetDefault("You can feel you have minor control over the land around you.");
		}

		public override void SetDefaults()
		{
			item.damage = 47;	
			item.melee = true;
			item.width = 54;	
			item.height = 54;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 11300;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 15);
			recipe.AddIngredient(ItemID.BladeofGrass, 1);
			recipe.AddIngredient(mod.ItemType("NanestineBar"), 25);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

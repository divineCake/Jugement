using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Judgement.Items.Weapons
{
	public class NanestineThrowingAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.shoot = mod.ProjectileType<Projectiles.NanestineTAxe>();
			item.shootSpeed = 10f;
			item.damage = 43;
			item.knockBack = 5f;
			item.thrown = true;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 34;
			item.height = 38;
			item.maxStack = 999;
			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NanestineBar"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}

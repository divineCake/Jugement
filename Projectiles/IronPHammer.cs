using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace namespace.Items
{
	public class IronPHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Paladin Hammer");
			Tooltip.SetDefault("This is the desc text.");
		}

		public override void SetDefaults()
		{
			item.noMelee = true;
			item.useStyle = 1;
			item.shootSpeed = 14f;
			item.shoot = mod.ProjectileType<Projectiles.IronPHammer>();
			item.damage = 4;
			item.knockBack = 5f;
			item.width = 14;
			item.height = 28;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.rare = 2;
			item.value = 1800;
			//Item.sellPrice(0, 10, 0, 0);
			item.melee = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

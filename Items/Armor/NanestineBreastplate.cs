using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Judgement.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NanestineBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Nanestine Breastplate");
			Tooltip.SetDefault("'Wielding Nanestine is like fixing a machine - you have to break a few things to get it to work.'"
				+ "\n+ 10 max health!");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NanestineBar"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
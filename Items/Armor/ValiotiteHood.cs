using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Judgement.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ValiotiteHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Valiotite Hood");
			Tooltip.SetDefault("'They said there was nothing like pure darkness. Then see what i have seen.'"
				+ "\n+ 10 max mana!");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ValiotiteBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
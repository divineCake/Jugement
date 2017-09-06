using Terraria.ID;
using Terraria.ModLoader;

namespace Judgement.Items.Placeable
{
	public class NanestineOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nanestine Ore");
			Tooltip.SetDefault("This ore seems like it is infected with some foul energy!");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.value = 1000;
			item.rare = 2;
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("Nanestine");
		}
	}
}

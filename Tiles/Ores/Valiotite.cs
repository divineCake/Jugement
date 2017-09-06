using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Judgement.Tiles.Ores
{
	public class Valiotite : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("ValiotiteOre");
			minPick = 65;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Valiotite Ore");
			AddMapEntry(new Color(127, 0, 255), name);
		}
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 20)
			{
				r = 0.25f;
				g = 0f;
				b = 0.75f;
			}
		}
	}
}
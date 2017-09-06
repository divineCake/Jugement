using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Judgement.Tiles.Ores
{
	public class Nanestine : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("NanestineOre");
			minPick = 65;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Nanestine Ore");
			AddMapEntry(new Color(7, 213, 1), name);
		}
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 20)
			{
				r = 0.0f;
				g = 0.75f;
				b = 0.0f;
			}
		}
	}
}
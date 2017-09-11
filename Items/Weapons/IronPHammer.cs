using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace namespace.Projectiles
{
	public class IronPHammer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Paladin Hammer");
		}

		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 38;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.extraUpdates = 2;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			float damFloat = damage * 0.03f;
			int damInt = (int)Math.Ceiling(damFloat);
			CombatText.NewText(new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height), new Color(35, 255, 80, 255), damInt, false, false);
			Main.player[Main.myPlayer].statLife += damInt;
		}
	}
}

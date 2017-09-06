using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Judgement.Projectiles
{
	public class NanestineTAxe : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nanestine Throwing Axe");
		}
	
		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
			return true;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++)
			{
				// Create a new dust
				int dustIndex = Dust.NewDust(usePos, projectile.width, projectile.height, 81, 0f, 0f, 0, default(Color), 1f);
				Dust currentDust = Main.dust[dustIndex]; // If you plan to access the dust often, it's a smart idea to make this local variable to make your life a bit easier
				// Modify some of the dust behaviour
				currentDust.position = (currentDust.position + projectile.Center) / 2f;
				currentDust.velocity += rotVector * 2f;
				currentDust.velocity *= 0.5f;
				currentDust.noGravity = true;
				usePos -= rotVector * 8f;
			}

			int item = 0;
			// Give the javelin some chance to drop and be able to be picked up again, this is an example of an exact drop chance (18%)
			if (Main.rand.NextFloat() < 0.18f)
			{
				item = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType<Items.Weapons.NanestineThrowingAxe>(), 1, false, 0, false, false);
			}

			// Sync the drop for multiplayer
			// Note the usage of Terraria.ID.MessageID, please use this!
			if (Main.netMode == 1 && item >= 0)
			{
				NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
			}
		}

			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{

				target.AddBuff(169 , 300, false);
		}
		private const float maxTicks = 45f;
		private const int alphaReduction = 25;
		public override void AI()
		{
		for (int i = 0; i < 1; i++)
            {
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 18,projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 1.50f);
                Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 0.9f;
            }
            projectile.rotation += 1.5f;   //this make the projctile to rotate
			{
				projectile.alpha -= alphaReduction;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.ai[0] == 0f)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] >= maxTicks)
				{
					float velXmult = 0.98f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
					float velYmult = 0.35f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
					projectile.ai[1] = maxTicks; // set ai1 to maxTicks continuously
					projectile.velocity.X = projectile.velocity.X * velXmult;
					projectile.velocity.Y = projectile.velocity.Y + velYmult;
				}
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!

				if (Main.rand.Next(3) == 0)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 18, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
					Main.dust[dustIndex].velocity += projectile.velocity * 0.3f;
					Main.dust[dustIndex].velocity *= 0.2f;
				}
				if (Main.rand.Next(4) == 0)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 39, 0f, 0f, 254, default(Color), 0.3f);
					Main.dust[dustIndex].velocity += projectile.velocity * 0.5f;
					Main.dust[dustIndex].velocity *= 0.5f;
					return;
				}
			}
			if (projectile.ai[0] == 1f)
			{
				projectile.ignoreWater = true; // Make sure the projectile ignores water
				projectile.tileCollide = false; // Make sure the projectile doesn't collide with tiles anymore
				int aiFactor = 15; // Change this factor to change the 'lifetime' of this sticking javelin
				bool killProj = false; // if true, kill projectile at the end
				bool hitEffect = false; // if true, perform a hit effect
				projectile.localAI[0] += 1f; 
				hitEffect = projectile.localAI[0] % 30f == 0f;
				int projTargetIndex = (int)projectile.ai[1];
				if (projectile.localAI[0] >= (float)(60 * aiFactor)) // If it's time for this javelin to die, kill it
				{
					killProj = true;
				}
				else if (projTargetIndex < 0 || projTargetIndex >= 200) // If the index is past its limits, kill the javelin
				{
					killProj = true;
				}
				else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) // If the target is active and can take damage
				{
					projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
					if (hitEffect) // Perform a hit effect here
					{
						Main.npc[projTargetIndex].HitEffect(0, 1.0);
					}
				}
				else
				{
					killProj = true;
				}

				if (killProj) // Kill the projectile
				{
					projectile.Kill();
				}
			}
		}
	}
}

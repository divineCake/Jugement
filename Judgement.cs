using Terraria.ModLoader;

namespace Judgement
{
	class Judgement : Mod
	{
		public Judgement()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}

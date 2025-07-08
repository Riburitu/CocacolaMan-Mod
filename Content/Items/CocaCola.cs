using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CocacolaMan.Content.Items
// Los alimentos tienen un sprite único para cuando se comen y para cuando se colocan.
// Esto se explica en los comentarios siguientes.
{
	public class CocaCola : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 5;

			Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 2));

			ItemID.Sets.DrinkParticleColors[Item.type] = new Color[] {
			    new Color(255, 50, 50),   // Rojo brillante con un poco de verde y azul para suavizar
			    new Color(200, 0, 0),     // Rojo oscuro intenso
			    new Color(255, 100, 100)  // Rojo claro
			};

		}

		public override void SetDefaults()
		{
			// Este código coincide con el del ApplePie.

			// DefaultToFood establece todos los valores predeterminados relacionados con la comida
			// como el tipo de buff, la duración del buff, el sonido al usar y el tiempo de animación.
			Item.DefaultToFood(22, 22, BuffID.WellFed3, 57600); // 57600 son 16 minutos: 16 * 60 * 60
			Item.value = Item.buyPrice(0, 3);
			Item.rare = ItemRarityID.Red;
    		Item.UseSound = SoundID.Item3; // Sonido de beber poción
		}

		// Si quieres varios buffs, puedes aplicar el resto con este método.
		// Asegúrate de que el buff principal esté definido en SetDefaults para que la tecla QuickBuff funcione bien.
		public override void OnConsumeItem(Player player)
		{
			player.AddBuff(192, 28800); // Buff de azucarado, dura 8 minutos.
			player.AddBuff(48, 28800); // Buff de miel, dura 8 minutos.
			player.AddBuff(207, 28800); // Buff de super alimentado, dura 8 minutos.
		}
		// Por favor, mira Content/ExampleRecipes.cs para una explicación detallada de la creación de recetas.
	}
}

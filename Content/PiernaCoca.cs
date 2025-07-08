using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CocacolaMan.Content
{
	// El atributo AutoloadEquip adjunta automáticamente una textura de equipamiento a este elemento.
	// Si se proporciona el valor EquipType.Body aquí, TML esperará que se coloque un archivo X_Body.png junto a la textura principal del elemento.	[AutoloadEquip(EquipType.Legs)]
	[AutoloadEquip(EquipType.Legs)]
	public class PiernaCoca : ModItem
	{
		public override void SetDefaults()
		{ // Establecemos las estadisticas del item.
			Item.width = 18; // Ancho
			Item.height = 18; // Alto
			Item.value = Item.sellPrice(gold: 5); // Vender
			Item.rare = ItemRarityID.Red; // Rareza del item
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(4018, 1) // ID de la Soda de Crema y 1 unidad.
			.AddIngredient(225, 10) // ID de la Seda y 10 unidades.
			.AddTile(332) // ID para crearlo, en este caso es un Telar.
			.Register(); // Registra esta receta en el juego.

		}
	}
}
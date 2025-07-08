using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CocacolaMan.Content
{
	// El atributo AutoloadEquip adjunta automáticamente una textura de equipamiento a este elemento.
	// Si se proporciona el valor EquipType.Body aquí, TML esperará que se coloque un archivo X_Body.png junto a la textura principal del elemento.	[AutoloadEquip(EquipType.Body)]
	[AutoloadEquip(EquipType.Body)]
	public class TorsoCoca : ModItem

	{
		public override void SetDefaults()
		{
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 5); // How many coins the item is worth
			Item.rare = ItemRarityID.Red; // The rarity of the item
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
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
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.GameContent.Personalities;
using ReLogic.Content;
using System.Collections.Generic;
using CocacolaMan.Content.Items;
using CocacolaMan.Content;

namespace CocacolaMan.Content.NPCs

{
	[AutoloadHead]
	public class Cocacolaman_NPC : ModNPC
	{
		public const string ShopName = "Shop";
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 25; // Cantidad de frames de tu sprite
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			// 1. Si ya fue desbloqueado, puede reaparecer
			if (CocacolaWorld.CocacolamanUnlocked)
			{
				return true;
			}

			// 2. Si tiene una CocaCola, se desbloquea
			foreach (Player player in Main.player)
			{
				if (!player.active) continue;

				foreach (Item item in player.inventory)
				{
					if (item.type == ItemID.JojaCola)
					{
						CocacolaWorld.CocacolamanUnlocked = true; // Desbloquear para siempre
						return true;
					}
				}
			}

			// 3. Si nada se cumple, no puede aparecer
			return false;
		}

		public override List<string> SetNPCNameList() {
			return new List<string>() { "CocacolaMan", "Cocaman", "Cokeman", "Don Cocacola", "CocaLight", "Señor AntiPepsi" };
		}

		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("¿Quieres una Coca-Cola?, compralas estan bien ricas.");
			chat.Add("No, no vendo Pepsi, lo siento.");
			chat.Add("¿Sabías que la cafeína mejora el DPS?");
            chat.Add("Un buen día es cuando te tomas una Coca-Cola en la mañana.");
            chat.Add("El gas de la Coca-Cola es muy sabrosa cuando estás bien cansado.");
            chat.Add("La cocacola no se puede comparar a la tal 'Pepsi', la Coca-Cola es eterna.");
            chat.Add("¿Matar fans de Pepsiman?, puede ser, pero no tanto.");
            chat.Add("¿Sabías qué?, la Joja-Soda y Cream Soda no estan nada mal, entiendelo, son parte de mi marca desde el principio.");
            chat.Add("Una vez persegui a Pepsiman por robarme, pero se escapo con todo mi equipo. Maldito Pepsiman...");
            chat.Add("Te puedo vender mi traje si deseas, ¡es increible tener otro yo jajaja!");
			return chat;
		}

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28"); // "Shop"
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shop)
		{
			if (firstButton)
			{
				shop = ShopName; // Esto abre la tienda "Default"
			}
		}
		public override void AddShops() {
			var npcShop = new NPCShop(Type, ShopName)
				.Add(5275)
				.Add(4018)
				.Add(ModContent.ItemType<CocaCola>())
				.Add(ModContent.ItemType<CocaColaZero>())
				.Add(ModContent.ItemType<CabezaCoca>())
				.Add(ModContent.ItemType<TorsoCoca>())
				.Add(ModContent.ItemType<PiernaCoca>());

			npcShop.Register();
		}

		public override ITownNPCProfile TownNPCProfile()
		{
			return new CocacolamanProfile();
		}
	}

	public class CocacolamanProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
			return ModContent.Request<Texture2D>("CocacolaMan/Content/NPCs/Cocacolaman_NPC");
		}

		public int GetHeadTextureIndex(NPC npc) {
			return ModContent.GetModHeadSlot("CocacolaMan/Content/NPCs/Cocacolaman_NPC_Head");
		}
	}
}

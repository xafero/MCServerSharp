using MCServerSharp.Data.Entities;

namespace MCServerSharp.Data.Items.Inventories {
	/// <summary>
	/// A player's inventory
	/// </summary>
	public class PlayerInventory : Inventory {
		public override ItemStack[] Items { get; }
		/// <summary>
		/// The player this inventory belongs to
		/// </summary>
		public Player Owner;
		/// <summary>
		/// Initialize a new inventory of a player
		/// </summary>
		public PlayerInventory(Player owner = null) {
			Owner = owner;
			Items = new ItemStack[36];
		}
	}
}
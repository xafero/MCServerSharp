namespace MCServerSharp.Data.Items.Inventories {
	/// <summary>
	/// A container that can store ItemStacks
	/// </summary>
	public class Inventory {
		/// <summary>
		/// All ItemStacks in the inventory
		/// </summary>
		public virtual ItemStack[] Items { get; }

		/// <summary>
		/// Initialize a new default inventory
		/// </summary>
		public Inventory() {
			Items = new ItemStack[27];
		}
	}
}
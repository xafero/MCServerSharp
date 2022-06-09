using System.Runtime.InteropServices;

namespace MCServerSharp.Data.Items {
	/// <summary>
	/// A stack of items that can be stored in a inventory
	/// </summary>
	public class ItemStack {
		/// <summary>
		/// Kind of item this stack stores
		/// </summary>
		public Item Item;
		/// <summary>
		/// The number of items stored in the stack
		/// </summary>
		public int Count;
		/// <summary>
		/// Make a copy of the ItemStack
		/// </summary>
		public ItemStack(Item item, int count) {
			Item = item;
			Count = count;
		}
		public ItemStack DeepClone() => new ItemStack(Item.DeepClone(), Count);
	}
}

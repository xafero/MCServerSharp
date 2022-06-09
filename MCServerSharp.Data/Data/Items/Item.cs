namespace MCServerSharp.Data.Items {
	public abstract class Item {
		/// <summary>
		/// Item id of the item
		/// </summary>
		public abstract int Id { get; }
		/// <summary>
		/// The maximum stacking capacity of the item
		/// </summary>
		public virtual int MaxStackCount { get; protected set; } = 64;
		/// <summary>
		/// Make a copy of the item
		/// </summary>
		public abstract Item DeepClone();
		/// <summary>
		/// Create a new instance of this item
		/// </summary>
		public abstract Item CreateInstance();
	}
}

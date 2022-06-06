using MCServerSharp.Data.NBTs;
using MCServerSharp.Data.Utils;
using MCServerSharp.Worlds;
using System.Collections.Generic;

namespace MCServerSharp.Data.Blocks {
	public abstract class Block : INBTTarget {
		/// <summary>
		/// All kinds of block
		/// </summary>
		public static List<Block> Blocks = new();
		/// <summary>
		/// The world in which the block is
		/// </summary>
		public World World;
		/// <summary>
		/// The position where the block is
		/// </summary>
		public Vector3 Position;
		/// <summary>
		/// ID of the block
		/// </summary>
		public abstract int ID { get; }
		/// <summary>
		/// Make a copy of the block
		/// </summary>
		public abstract Block DeepClone();
		/// <summary>
		/// Create a new instance of this block
		/// </summary>
		public abstract Block CreateInstance();

		/// <summary>
		/// Initialize all blocks
		/// </summary>
		static Block() {
			for (var i = 0; i < 454; ++i)
				Blocks.Add(new VirtualBlock(i));
		}
	}
}

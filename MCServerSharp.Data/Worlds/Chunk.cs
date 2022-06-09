using MCServerSharp.Data.Utils;
using MCServerSharp.Data.Blocks;
using System.Collections.Generic;

namespace MCServerSharp.Worlds {
	public class Chunk {
		public readonly int X;
		public readonly int Z;
		public readonly SortedList<int, Block[,]> Blocks = new();

		public Chunk(int x, int z) {
			X = x;
			Z = z;
		}
		public virtual void SetBlocks(Vector3 pos1, Vector3 pos2, Block block) {
			SetBlocks(pos1.X, pos1.Y, pos1.Z, pos2.X, pos2.Y, pos2.Z, block);
		}
		public virtual void SetBlocks(int x1, int y1, int z1, int x2, int y2, int z2, Block block) {
			SetBlocksWithoutEvents(x1, y1, z1, x2, y2, z2, block);
			//TODO event
		}
		protected internal virtual void SetBlocksWithoutEvents(int x1, int y1, int z1, int x2, int y2, int z2, Block block) {
			Util.Sort(ref x1, ref x2);
			Util.Sort(ref y1, ref y2);
			Util.Sort(ref z1, ref z2);
			for (var y = y1; y <= y2; ++y) {
				if (!Blocks.TryGetValue(y, out var blocks))
					Blocks.Add(y, blocks = new Block[16, 16]);
				for (var z = z1; z <= z2; ++z)
					for (var x = x1; x <= x2; ++x)
						blocks[x, z] = block;
			}
		}
		public virtual void SetBlock(Vector3 pos, Block block) {
			SetBlock(pos.X, pos.Y, pos.Z, block);
		}
		public virtual void SetBlock(int x, int y, int z, Block block) {
			if (!Blocks.TryGetValue(y, out var blocks))
				Blocks.Add(y, blocks = new Block[16, 16]);
			blocks[x, z] = block;
			//TODO event
		}
		public virtual Block GetBlock(Vector3 pos) {
			return GetBlock(pos.X, pos.Y, pos.Z);
		}
		public virtual Block GetBlock(int x, int y, int z) {
			if (!Blocks.TryGetValue(y, out var blocks)) return null;
			return blocks[x,z];
		}
	}
}
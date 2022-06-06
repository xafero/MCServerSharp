using MCServerSharp.Data.Utils;
using MCServerSharp.Data.Blocks;
using MCServerSharp.Data.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NbtWorld = Substrate.NbtWorld;

namespace MCServerSharp.Worlds {
	public class World {
		public readonly string Name;
		public readonly SortedList<Vector2, Chunk> Chunks = new(Vector2.Comparer.Instance);
		public ReadOnlyCollection<Entity> Entities => entities.AsReadOnly();
		public ReadOnlyCollection<Player> Players => players.AsReadOnly();
		protected readonly List<Entity> entities = new();
		protected readonly List<Player> players = new();
		public World(string name) {
			Name = name;
			var cm = NbtWorld.Open(name).GetChunkManager();
			foreach (var c in cm) {
				var chunk = new Chunk(c.X, c.Z);
				for (var y = 0; y < 16; ++y) {
					var b = new Block[16, 16];
					for (var x = 0; x < 16; ++x)
						for (var z = 0; z < 16; ++z)
							b[x, z] = new VirtualBlock(c.Blocks.GetID(x, y, z));
					chunk.Blocks[y] = b;
				}
				Chunks.Add(new(chunk.X, chunk.Z), chunk);
			}
		}
		public virtual void SetBlocks(int x1, int y1, int z1, int x2, int y2, int z2, Block block) {
			Util.Sort(ref x1, ref x2);
			Util.Sort(ref y1, ref y2);
			Util.Sort(ref z1, ref z2);
			var x12 = x1 < 0 ? (x1 + 1) % 16 + 15 : x1 % 16;
			var z12 = z1 < 0 ? (z1 + 1) % 16 + 15 : z1 % 16;
			x1 = x1 < 0 ? (x1 + 1) / 16 - 1 : x1 / 16;
			z1 = z1 < 0 ? (z1 + 1) / 16 - 1 : z1 / 16;
			var x22 = x2 < 0 ? (x2 + 1) % 16 + 15 : x2 % 16;
			var z22 = z2 < 0 ? (z2 + 1) % 16 + 15 : z2 % 16;
			x2 = x2 < 0 ? (x2 + 1) / 16 - 1 : x2 / 16;
			z2 = z2 < 0 ? (z2 + 1) / 16 - 1 : z2 / 16;
			for (var x = x1; x <= x2; ++x)
				for (var z = z1; z <= z2; ++z) {
					var x13 = x > x1 ? 0 : x12;
					var z13 = z > z1 ? 0 : z12;
					var x23 = x < x2 ? 15 : x22;
					var z23 = z < z2 ? 15 : z22;
					GetChunk(new Vector2(x, z)).SetBlocksWithoutEvents(x13, y1, z13, x23, y2, z23, block);
				}
			//TODO event
		}
		public virtual void SetBlocks(Vector3 pos1, Vector3 pos2, Block block) {
			SetBlocks(pos1.X, pos1.Y, pos1.Z, pos2.X, pos2.Y, pos2.Z, block);
		}
		public virtual void SetBlock(int x, int y, int z, Block block) {
			var x2 = x < 0 ? (x + 1) % 16 + 15 : x % 16;
			var z2 = z < 0 ? (z + 1) % 16 + 15 : z % 16;
			x = x < 0 ? (x + 1) / 16 - 1 : x / 16;
			z = z < 0 ? (z + 1) / 16 - 1 : z / 16;
			GetChunk(new Vector2(x, z)).SetBlock(x2, y, z2, block);
		}
		public virtual void SetBlock(Vector3 pos, Block block) {
			SetBlock(pos.X, pos.Y, pos.Z, block);
		}
		public virtual Block GetBlock(int x, int y, int z) {
			var x2 = x < 0 ? (x + 1) % 16 + 15 : x % 16;
			var z2 = z < 0 ? (z + 1) % 16 + 15 : z % 16;
			x = x < 0 ? (x + 1) / 16 - 1 : x / 16;
			z = z < 0 ? (z + 1) / 16 - 1 : z / 16;
			return GetChunk(new Vector2(x, z)).GetBlock(x2, y, z2);
		}
		public virtual Block GetBlock(Vector3 pos) {
			return GetBlock(pos.X, pos.Y, pos.Z);
		}
		public virtual Chunk GetChunk(int x, int z) {
			return GetChunk(new Vector2(x, z));
		}
		public virtual Chunk GetChunk(Vector2 pos) {
			return Chunks[pos];
		}
		public virtual void AddEntity(Entity entity) {
			entities.Add(entity);
			if (entity is Player p)
				players.Add(p);
		}
		public virtual bool RemoveEntity(Entity entity) {
			if (entity is Player p)
				players.Remove(p);
			return entities.Remove(entity);
		}

		public static World GetWorld(string name) {
			return Server.Instance.Worlds.Find(w => w.Name == name);
		}
	}
}

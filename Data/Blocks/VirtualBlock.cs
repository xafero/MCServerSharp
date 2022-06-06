using MCServerSharp.Data.Utils;
using MCServerSharp.Worlds;

namespace MCServerSharp.Data.Blocks {
	/// <summary>
	/// To represent all undefined blocks
	/// </summary>
	public class VirtualBlock : Block {
		public override int ID { get; }
		/// <summary>
		/// Initialize a <see cref="VirtualBlock"/> with a block <paramref name="id"/>
		/// </summary>
		/// <param name="id">Block id</param>
		public VirtualBlock(int id) {
			ID = id;
		}

		public override Block DeepClone() => MemberwiseClone() as Block;
		public override Block CreateInstance() => new VirtualBlock(ID);
	}
}
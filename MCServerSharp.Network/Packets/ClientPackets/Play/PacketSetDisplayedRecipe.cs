using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSetDisplayedRecipe : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 31;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSetDisplayedRecipe();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
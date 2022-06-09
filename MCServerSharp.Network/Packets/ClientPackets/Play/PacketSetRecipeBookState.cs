using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSetRecipeBookState : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 30;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSetRecipeBookState();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
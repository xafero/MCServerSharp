using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketUpdateclassureBlock : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 42;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketUpdateclassureBlock();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
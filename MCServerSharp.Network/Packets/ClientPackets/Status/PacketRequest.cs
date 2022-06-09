using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Status {
	public class PacketRequest : IClientPacket {
		public State PacketState => State.Status;
		public byte PacketId => 0;
		public Span<byte> Bytes => Span<byte>.Empty;

		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket DeepClone() => new PacketRequest();
		public IPacket CreateInstance() => new PacketRequest();
	}
}

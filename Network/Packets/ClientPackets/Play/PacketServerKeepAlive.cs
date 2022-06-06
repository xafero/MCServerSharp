using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerKeepAlive : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 16;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerKeepAlive();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
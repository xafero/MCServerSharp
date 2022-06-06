using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerHeldItemChange : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 37;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerHeldItemChange();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
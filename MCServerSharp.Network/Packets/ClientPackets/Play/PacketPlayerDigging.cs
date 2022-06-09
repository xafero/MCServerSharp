using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketPlayerDigging : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 27;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketPlayerDigging();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
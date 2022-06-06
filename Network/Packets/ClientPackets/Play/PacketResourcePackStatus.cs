using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketResourcePackStatus : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 33;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketResourcePackStatus();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
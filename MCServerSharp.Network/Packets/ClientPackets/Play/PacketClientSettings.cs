using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketClientSettings : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 6;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketClientSettings();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
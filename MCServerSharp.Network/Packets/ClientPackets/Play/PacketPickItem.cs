using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketPickItem : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 24;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketPickItem();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
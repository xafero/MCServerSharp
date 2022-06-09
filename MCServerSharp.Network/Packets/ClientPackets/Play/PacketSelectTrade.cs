using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSelectTrade : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 35;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSelectTrade();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
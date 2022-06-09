using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketEditBook : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 13;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketEditBook();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
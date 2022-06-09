using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerChatMessage : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 4;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerChatMessage();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
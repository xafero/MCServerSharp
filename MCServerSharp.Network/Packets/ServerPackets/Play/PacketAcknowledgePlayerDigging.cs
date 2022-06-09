using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketAcknowledgePlayerDigging : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 7;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketAcknowledgePlayerDigging();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
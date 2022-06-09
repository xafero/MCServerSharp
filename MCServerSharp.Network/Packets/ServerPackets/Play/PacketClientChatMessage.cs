using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientChatMessage : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 14;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientChatMessage();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
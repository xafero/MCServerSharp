using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityMetadata : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 68;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityMetadata();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
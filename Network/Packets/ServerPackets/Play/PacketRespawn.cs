using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketRespawn : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 57;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketRespawn();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
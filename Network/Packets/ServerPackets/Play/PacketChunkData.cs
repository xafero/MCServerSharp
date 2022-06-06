using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketChunkData : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 32;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketChunkData();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
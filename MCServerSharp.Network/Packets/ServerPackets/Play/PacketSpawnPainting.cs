using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSpawnPainting : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 3;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSpawnPainting();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
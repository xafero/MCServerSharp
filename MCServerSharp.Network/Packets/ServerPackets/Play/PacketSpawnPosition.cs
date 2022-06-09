using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSpawnPosition : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 66;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSpawnPosition();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
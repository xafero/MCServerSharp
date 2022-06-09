using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSpawnPlayer : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 4;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSpawnPlayer();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
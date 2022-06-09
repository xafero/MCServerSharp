using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSpawnEntity : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 0;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSpawnEntity();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
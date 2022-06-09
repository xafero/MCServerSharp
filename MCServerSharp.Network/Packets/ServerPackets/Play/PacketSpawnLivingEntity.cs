using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSpawnLivingEntity : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 2;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSpawnLivingEntity();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
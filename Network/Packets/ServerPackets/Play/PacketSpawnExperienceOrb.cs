using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSpawnExperienceOrb : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 1;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSpawnExperienceOrb();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
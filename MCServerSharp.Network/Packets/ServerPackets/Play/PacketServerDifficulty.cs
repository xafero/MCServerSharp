using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketServerDifficulty : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 13;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketServerDifficulty();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketStatistics : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 6;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketStatistics();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
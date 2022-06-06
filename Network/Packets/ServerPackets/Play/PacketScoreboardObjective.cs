using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketScoreboardObjective : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 74;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketScoreboardObjective();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
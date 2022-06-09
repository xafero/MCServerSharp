using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketDisplayScoreboard : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 67;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketDisplayScoreboard();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
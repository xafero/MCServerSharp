using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketJoinGame : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 36;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketJoinGame();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
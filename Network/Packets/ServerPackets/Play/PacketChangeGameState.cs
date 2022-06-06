using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketChangeGameState : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 29;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketChangeGameState();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
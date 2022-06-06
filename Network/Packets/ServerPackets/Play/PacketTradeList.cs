using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketTradeList : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 38;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketTradeList();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
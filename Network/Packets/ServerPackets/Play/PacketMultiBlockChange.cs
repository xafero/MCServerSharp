using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketMultiBlockChange : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 59;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketMultiBlockChange();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
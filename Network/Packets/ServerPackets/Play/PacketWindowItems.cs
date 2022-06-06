using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketWindowItems : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 19;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketWindowItems();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
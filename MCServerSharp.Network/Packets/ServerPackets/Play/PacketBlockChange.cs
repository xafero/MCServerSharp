using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketBlockChange : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 11;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketBlockChange();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
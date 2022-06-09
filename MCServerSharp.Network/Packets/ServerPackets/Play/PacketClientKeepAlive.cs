using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientKeepAlive : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 31;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientKeepAlive();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
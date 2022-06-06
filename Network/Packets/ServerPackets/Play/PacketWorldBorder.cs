using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketWorldBorder : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 61;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketWorldBorder();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
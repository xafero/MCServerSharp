using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketTitle : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 79;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketTitle();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
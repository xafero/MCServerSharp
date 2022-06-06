using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketTags : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 91;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketTags();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketPlayerListHeaderAndFooter : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 83;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketPlayerListHeaderAndFooter();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
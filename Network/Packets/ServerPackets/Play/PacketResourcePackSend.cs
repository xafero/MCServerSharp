using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketResourcePackSend : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 56;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketResourcePackSend();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
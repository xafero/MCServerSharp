using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketAttachEntity : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 69;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketAttachEntity();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
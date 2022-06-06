using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Status {
	public class PacketPong : IServerPacket {
		public State PacketState => State.Status;
		public byte PacketId => 1;
		public Span<byte> Bytes => Payload.GetBytes();

		public long Payload;

		public PacketPong(long Payload) {
			this.Payload = Payload;
		}

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
		public IPacket CreateInstance() => new PacketPong(0);
	}
}
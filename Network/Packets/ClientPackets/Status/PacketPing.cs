using MCServerSharp.Data.Utils;
using MCServerSharp.Network.Packets.ServerPackets.Status;
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Status {
	public class PacketPing : IClientPacket {
		public State PacketState => State.Status;
		public byte PacketId => 1;
		public Span<byte> Bytes => Payload.GetBytes();

		public long Payload;

		public PacketPing(long Payload) {
			this.Payload = Payload;
		}

		public PacketPong GetPong() => new PacketPong(Payload);

		public IClientPacket Parse(Span<byte> buffer) {
			Payload = buffer.ToInt64();
			return this;
		}

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
		public IPacket CreateInstance() => new PacketPing(0);
	}
}
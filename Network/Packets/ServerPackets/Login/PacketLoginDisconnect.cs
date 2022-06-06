using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Login {
	public class PacketLoginDisconnect : IServerPacket {
		public State PacketState => State.Login;
		public byte PacketId => 0;
		public Span<byte> Bytes => Reason.AsSpan().GetBytes();

		public string Reason;

		public PacketLoginDisconnect(string Reason) {
			this.Reason = Reason;
		}

		public IPacket CreateInstance() => new PacketLoginDisconnect(null);

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}

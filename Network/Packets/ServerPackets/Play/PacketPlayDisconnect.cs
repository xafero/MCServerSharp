using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketPlayDisconnect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 25;

		public Span<byte> Bytes => Reason.AsSpan().GetBytes();

		public string Reason;

		public PacketPlayDisconnect(string Reason) {
			this.Reason = Reason;
		}

		public IPacket CreateInstance() => new PacketPlayDisconnect(null);

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
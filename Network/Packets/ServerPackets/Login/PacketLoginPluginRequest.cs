using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Login {
	public class PacketLoginPluginRequest : IServerPacket {
		public State PacketState => State.Login;

		public byte PacketId => 4;

		public VarInt MessageID;
		public string Channel;
		public byte[] Data;

		public Span<byte> Bytes {
			get {
				var a1 = MessageID.Buffer;
				var a2 = Channel.AsSpan().GetBytes();
				var b = new byte[a1.Length + a2.Length + Data.Length];
				Buffer.BlockCopy(a1, 0, b, 0, a1.Length);
				Buffer.BlockCopy(a2, 0, b, a1.Length, a2.Length);
				Buffer.BlockCopy(Data, 0, b, a1.Length + a2.Length, Data.Length);
				return b;
			}
		}

		public IPacket CreateInstance() => null;

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}

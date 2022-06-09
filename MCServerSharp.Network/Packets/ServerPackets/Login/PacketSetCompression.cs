using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Login {
	public class PacketSetCompression : IServerPacket {
		public State PacketState => State.Login;

		public byte PacketId => 3;

		public Span<byte> Bytes => Threshold.Buffer;

		public VarInt Threshold;

		public IPacket CreateInstance() => null;

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}

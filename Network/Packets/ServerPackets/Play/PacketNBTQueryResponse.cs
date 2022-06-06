using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketNBTQueryResponse : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 84;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketNBTQueryResponse();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
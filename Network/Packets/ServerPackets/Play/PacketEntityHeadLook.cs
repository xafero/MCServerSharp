using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityHeadLook : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 58;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityHeadLook();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
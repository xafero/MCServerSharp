using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityMovement : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 42;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityMovement();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
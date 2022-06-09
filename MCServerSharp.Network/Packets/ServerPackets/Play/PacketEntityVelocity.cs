using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityVelocity : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 70;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityVelocity();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
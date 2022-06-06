using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientPlayerPositionAndLook : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 52;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientPlayerPositionAndLook();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
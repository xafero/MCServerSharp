using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityPositionandRotation : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 40;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityPositionandRotation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
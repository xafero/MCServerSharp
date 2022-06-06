using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketBlockBreakAnimation : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 8;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketBlockBreakAnimation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
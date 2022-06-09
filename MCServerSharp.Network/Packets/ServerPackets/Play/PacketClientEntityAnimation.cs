using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientEntityAnimation : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 5;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientEntityAnimation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
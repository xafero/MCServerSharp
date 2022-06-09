using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEffect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 33;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
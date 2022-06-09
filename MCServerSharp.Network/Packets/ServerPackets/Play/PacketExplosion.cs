using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketExplosion : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 27;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketExplosion();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
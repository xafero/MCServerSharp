using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketParticle : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 34;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketParticle();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
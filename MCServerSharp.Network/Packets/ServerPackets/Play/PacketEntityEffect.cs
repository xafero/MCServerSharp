using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityEffect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 89;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
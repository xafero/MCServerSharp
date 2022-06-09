using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketRemoveEntityEffect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 55;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketRemoveEntityEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
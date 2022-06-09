using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketAdvancements : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 87;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketAdvancements();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
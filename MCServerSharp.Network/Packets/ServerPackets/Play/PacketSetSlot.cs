using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSetSlot : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 21;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSetSlot();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
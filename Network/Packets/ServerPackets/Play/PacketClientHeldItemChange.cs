using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientHeldItemChange : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 63;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientHeldItemChange();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
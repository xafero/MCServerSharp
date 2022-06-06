using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketCollectItem : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 85;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketCollectItem();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketMapData : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 37;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketMapData();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
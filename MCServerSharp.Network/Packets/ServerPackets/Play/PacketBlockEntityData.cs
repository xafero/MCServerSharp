using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketBlockEntityData : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 9;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketBlockEntityData();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
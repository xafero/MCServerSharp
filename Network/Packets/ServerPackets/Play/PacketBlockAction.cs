using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketBlockAction : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 10;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketBlockAction();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
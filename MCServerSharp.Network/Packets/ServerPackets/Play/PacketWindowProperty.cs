using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketWindowProperty : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 20;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketWindowProperty();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
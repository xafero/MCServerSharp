using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUnloadChunk : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 28;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUnloadChunk();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
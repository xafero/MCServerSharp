using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketTimeUpdate : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 78;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketTimeUpdate();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
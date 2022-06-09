using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketDestroyEntities : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 54;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketDestroyEntities();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
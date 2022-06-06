using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketOpenBook : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 44;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketOpenBook();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
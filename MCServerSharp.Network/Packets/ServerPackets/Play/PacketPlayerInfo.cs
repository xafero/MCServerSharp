using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketPlayerInfo : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 50;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketPlayerInfo();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
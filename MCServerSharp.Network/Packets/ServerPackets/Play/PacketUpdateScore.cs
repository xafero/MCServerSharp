using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUpdateScore : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 77;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUpdateScore();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUpdateHealth : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 73;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUpdateHealth();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
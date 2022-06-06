using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUpdateLight : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 35;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUpdateLight();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUpdateViewPosition : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 64;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUpdateViewPosition();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
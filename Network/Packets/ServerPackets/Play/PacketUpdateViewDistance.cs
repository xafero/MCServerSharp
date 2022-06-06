using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUpdateViewDistance : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 65;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUpdateViewDistance();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
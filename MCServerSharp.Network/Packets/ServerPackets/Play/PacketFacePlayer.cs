using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketFacePlayer : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 51;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketFacePlayer();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
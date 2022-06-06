using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientPlayerAbilities : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 48;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientPlayerAbilities();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
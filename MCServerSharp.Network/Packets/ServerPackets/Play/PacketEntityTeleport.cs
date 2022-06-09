using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityTeleport : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 86;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityTeleport();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
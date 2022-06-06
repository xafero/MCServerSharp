using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSetCooldown : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 22;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSetCooldown();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
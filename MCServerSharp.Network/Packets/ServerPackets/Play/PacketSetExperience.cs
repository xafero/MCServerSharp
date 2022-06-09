using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSetExperience : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 72;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSetExperience();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
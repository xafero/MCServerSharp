using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityProperties : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 88;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityProperties();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
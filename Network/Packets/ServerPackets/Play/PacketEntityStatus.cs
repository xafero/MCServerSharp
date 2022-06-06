using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityStatus : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 26;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityStatus();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
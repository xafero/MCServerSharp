using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketStopSound : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 82;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketStopSound();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
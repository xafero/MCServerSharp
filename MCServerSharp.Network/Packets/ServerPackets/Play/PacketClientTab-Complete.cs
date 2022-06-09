using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientTabComplete : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 15;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientTabComplete();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
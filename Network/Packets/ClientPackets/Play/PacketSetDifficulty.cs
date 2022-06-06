using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSetDifficulty : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 3;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSetDifficulty();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
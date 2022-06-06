using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketLockDifficulty : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 17;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketLockDifficulty();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
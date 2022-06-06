using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketQueryBlockNBT : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 1;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketQueryBlockNBT();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketQueryEntityNBT : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 2;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketQueryEntityNBT();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
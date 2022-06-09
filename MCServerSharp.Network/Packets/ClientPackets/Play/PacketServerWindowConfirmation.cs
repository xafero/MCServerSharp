using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerWindowConfirmation : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 8;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerWindowConfirmation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
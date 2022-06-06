using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketPlayerMovement : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 21;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketPlayerMovement();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
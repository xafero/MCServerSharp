using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketEntityAction : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 28;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketEntityAction();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketInteractEntity : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 14;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketInteractEntity();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
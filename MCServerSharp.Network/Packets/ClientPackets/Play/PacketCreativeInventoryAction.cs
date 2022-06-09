using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketCreativeInventoryAction : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 40;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketCreativeInventoryAction();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
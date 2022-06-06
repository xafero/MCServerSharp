using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketPlayerBlockPlacement : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 46;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketPlayerBlockPlacement();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
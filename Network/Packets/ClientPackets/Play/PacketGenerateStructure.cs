using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketGenerateclassure : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 15;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketGenerateclassure();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
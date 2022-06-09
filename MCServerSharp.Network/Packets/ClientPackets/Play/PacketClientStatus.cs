using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketClientStatus : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 5;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketClientStatus();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
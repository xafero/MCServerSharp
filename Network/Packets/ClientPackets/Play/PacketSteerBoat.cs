using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSteerBoat : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 23;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSteerBoat();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketUpdateSign : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 43;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketUpdateSign();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketUpdateCommandBlock : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 38;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketUpdateCommandBlock();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
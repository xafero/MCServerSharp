using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketUpdateJigsawBlock : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 41;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketUpdateJigsawBlock();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
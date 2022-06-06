using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerTabComplete : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 7;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerTabComplete();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
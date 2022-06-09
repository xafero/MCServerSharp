using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerPlayerAbilities : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 26;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerPlayerAbilities();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
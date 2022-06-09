using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSpectate : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 45;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSpectate();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
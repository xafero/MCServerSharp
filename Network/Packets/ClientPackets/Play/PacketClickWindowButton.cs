using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketClickWindowButton : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 9;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketClickWindowButton();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
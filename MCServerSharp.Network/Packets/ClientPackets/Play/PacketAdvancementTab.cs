using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketAdvancementTab : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 34;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketAdvancementTab();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketClickWindow : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 10;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketClickWindow();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
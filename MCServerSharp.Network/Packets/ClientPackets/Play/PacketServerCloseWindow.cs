using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerCloseWindow : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 11;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerCloseWindow();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
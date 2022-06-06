using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketPlayerRotation : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 20;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketPlayerRotation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
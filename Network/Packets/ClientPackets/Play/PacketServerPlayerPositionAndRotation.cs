using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerPlayerPositionAndRotation : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 19;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerPlayerPositionAndRotation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
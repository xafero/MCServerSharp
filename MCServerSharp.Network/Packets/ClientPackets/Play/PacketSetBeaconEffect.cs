using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSetBeaconEffect : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 36;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSetBeaconEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
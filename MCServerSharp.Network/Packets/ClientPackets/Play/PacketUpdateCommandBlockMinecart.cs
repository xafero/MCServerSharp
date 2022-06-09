using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketUpdateCommandBlockMinecart : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 39;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketUpdateCommandBlockMinecart();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketServerPluginMessage : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 12;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketServerPluginMessage();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketUseItem : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 47;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketUseItem();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
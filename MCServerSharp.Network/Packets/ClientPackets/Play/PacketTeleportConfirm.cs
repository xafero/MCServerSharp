using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketTeleportConfirm : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 0;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketTeleportConfirm();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
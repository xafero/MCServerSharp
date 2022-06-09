using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketSteerVehicle : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 29;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketSteerVehicle();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
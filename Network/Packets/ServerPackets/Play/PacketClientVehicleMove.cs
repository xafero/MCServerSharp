using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientVehicleMove : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 43;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientVehicleMove();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
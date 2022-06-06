using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSetPassengers : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 75;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSetPassengers();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
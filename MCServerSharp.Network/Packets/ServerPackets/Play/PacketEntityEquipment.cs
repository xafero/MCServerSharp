using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityEquipment : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 71;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityEquipment();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
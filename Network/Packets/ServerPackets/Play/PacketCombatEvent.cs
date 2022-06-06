using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketCombatEvent : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 49;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketCombatEvent();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
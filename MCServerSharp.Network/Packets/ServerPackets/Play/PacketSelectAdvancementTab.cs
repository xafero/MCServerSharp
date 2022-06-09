using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSelectAdvancementTab : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 60;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSelectAdvancementTab();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
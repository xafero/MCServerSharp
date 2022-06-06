using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketBossBar : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 12;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketBossBar();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
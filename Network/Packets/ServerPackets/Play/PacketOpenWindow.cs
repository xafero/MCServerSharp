using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketOpenWindow : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 45;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketOpenWindow();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientCloseWindow : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 18;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientCloseWindow();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
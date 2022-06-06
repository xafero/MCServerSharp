using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketOpenSignEditor : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 46;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketOpenSignEditor();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
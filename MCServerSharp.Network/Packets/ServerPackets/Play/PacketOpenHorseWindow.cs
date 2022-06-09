using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketOpenHorseWindow : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 30;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketOpenHorseWindow();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
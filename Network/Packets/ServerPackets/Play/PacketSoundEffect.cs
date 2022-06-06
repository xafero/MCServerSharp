using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketSoundEffect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 81;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketSoundEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
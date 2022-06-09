using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketNamedSoundEffect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 24;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketNamedSoundEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
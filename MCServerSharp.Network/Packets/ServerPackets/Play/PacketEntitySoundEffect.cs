using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntitySoundEffect : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 80;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntitySoundEffect();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
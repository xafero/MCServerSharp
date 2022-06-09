using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientPluginMessage : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 23;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientPluginMessage();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
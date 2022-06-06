using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityPosition : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 39;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityPosition();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
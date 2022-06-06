using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketCamera : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 62;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketCamera();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
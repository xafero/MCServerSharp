using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketEntityRotation : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 41;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketEntityRotation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
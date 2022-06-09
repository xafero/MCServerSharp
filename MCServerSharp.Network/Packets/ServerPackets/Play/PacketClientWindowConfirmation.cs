using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketClientWindowConfirmation : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 17;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketClientWindowConfirmation();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
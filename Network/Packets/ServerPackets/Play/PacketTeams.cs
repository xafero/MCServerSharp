using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketTeams : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 76;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketTeams();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
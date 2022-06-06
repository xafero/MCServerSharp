using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketDeclareRecipes : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 90;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketDeclareRecipes();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
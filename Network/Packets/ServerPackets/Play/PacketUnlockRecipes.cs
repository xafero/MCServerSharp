using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketUnlockRecipes : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 53;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketUnlockRecipes();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
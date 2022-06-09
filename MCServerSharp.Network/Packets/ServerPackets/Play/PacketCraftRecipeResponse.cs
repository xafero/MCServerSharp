using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketCraftRecipeResponse : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 47;

		public Span<byte> Bytes => null;

		public IPacket CreateInstance() => new PacketCraftRecipeResponse();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
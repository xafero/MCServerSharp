using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Play {
	public class PacketCraftRecipeRequest : IClientPacket {
		public State PacketState => State.Play;

		public byte PacketId => 25;

		public Span<byte> Bytes => null;
		
		public IClientPacket Parse(Span<byte> buffer) {
			return this;
		}

		public IPacket CreateInstance() => new PacketCraftRecipeRequest();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
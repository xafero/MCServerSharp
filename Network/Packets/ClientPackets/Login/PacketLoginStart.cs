using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Login {
	public class PacketLoginStart : IClientPacket {
		public State PacketState => State.Login;

		public byte PacketId => 0;

		public string UserName;

		public IClientPacket Parse(Span<byte> buffer) {
			UserName = buffer.GetString();
			return this;
		}

		public IPacket CreateInstance() => new PacketLoginStart();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
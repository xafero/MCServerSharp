using MCServerSharp.Data.Utils;
using System;
using System.Linq;

namespace MCServerSharp.Network.Packets.ServerPackets.Login {
	public class PacketLoginSuccess : IServerPacket {
		public State PacketState => State.Login;

		public byte PacketId => 2;

		public Span<byte> Bytes => Username.AsSpan().GetBytes().Concat(UUID.Bytes).ToArray();

		public UUID UUID;
		public string Username;

		public PacketLoginSuccess(UUID UUID, string Username) {
			this.UUID = UUID;
			this.Username = Username;
		}

		public IPacket CreateInstance() => null;

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}

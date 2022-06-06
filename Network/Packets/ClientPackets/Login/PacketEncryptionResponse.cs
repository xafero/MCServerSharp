using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Login {
	public class PacketEncryptionResponse : IClientPacket {
		public State PacketState => State.Login;

		public byte PacketId => 1;

		public byte[] SharedSecret;
		public byte[] VerifyToken;

		public IClientPacket Parse(Span<byte> buffer) {
			var l = buffer.ReadVarInt(out int i);
			SharedSecret = buffer[l..i].ToArray();
			l = buffer.ReadVarInt(out i);
			VerifyToken = buffer[l..i].ToArray();
			return this;
		}

		public IPacket CreateInstance() => new PacketEncryptionResponse();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
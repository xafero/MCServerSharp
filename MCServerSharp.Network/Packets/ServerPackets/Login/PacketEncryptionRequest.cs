using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Login {
	public class PacketEncryptionRequest : IServerPacket {
		public State PacketState => State.Login;

		public byte PacketId => 1;

		public Span<byte> Bytes {
			get {
				var a1 = ServerID.AsSpan().GetBytes(20);
				var a2 = new VarInt(PublicKey.Length).Buffer;
				var a4 = new VarInt(VerifyToken.Length).Buffer;
				var b = new byte[a1.Length + a2.Length + PublicKey.Length + a4.Length + VerifyToken.Length];
				var ofs = a1.Length;
				Buffer.BlockCopy(a1, 0, b, 0, a1.Length);
				Buffer.BlockCopy(a2, 0, b, ofs, a2.Length);
				ofs += a2.Length;
				Buffer.BlockCopy(PublicKey, 0, b, ofs, PublicKey.Length);
				ofs += PublicKey.Length;
				Buffer.BlockCopy(a4, 0, b, ofs, a1.Length);
				ofs += a4.Length;
				Buffer.BlockCopy(VerifyToken, 0, b, ofs, VerifyToken.Length);
				return b;
			}
		}

		public string ServerID;
		public byte[] PublicKey;
		public byte[] VerifyToken;

		public IPacket CreateInstance() => null;

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}

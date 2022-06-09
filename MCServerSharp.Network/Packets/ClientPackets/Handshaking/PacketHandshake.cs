using MCServerSharp.Data.Utils;
using System;
using System.IO;

namespace MCServerSharp.Network.Packets.ClientPackets.Handshaking {
	public class PacketHandshake : IClientPacket {
		public State PacketState => State.Handshaking;
		public byte PacketId => 0;
		public Span<byte> Bytes {
			get {
				var a1 = new VarInt(ProtocolVersion).Buffer;
				var a2 = ServerAddress.AsSpan().GetBytes(255);
				var a3 = ServerPort.GetBytes();
				var a4 = new VarInt((int)NextState).Buffer;
				Span<byte> b = new byte[a1.Length + a2.Length + 2 + a4.Length];
				a1.CopyTo(b);
				a2.CopyTo(b[a1.Length..]);
				a3.CopyTo(b[(a1.Length + a2.Length)..]);
				a4.CopyTo(b[(a1.Length + a2.Length + 2)..]);
				return b;
			}
		}

		public int ProtocolVersion;
		public string ServerAddress;
		public ushort ServerPort;
		public State NextState;

		public IClientPacket Parse(Span<byte> buffer) {
			var offset = buffer.ReadVarInt(out ProtocolVersion);
			offset += buffer[offset..].GetString(out ServerAddress);
			ServerPort = (ushort)buffer[offset..].ToInt16();
			NextState = (State)buffer[(offset + 2)..].ReadVarInt();
			return this;
		}

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
		public IPacket CreateInstance() => new PacketHandshake();
	}
}
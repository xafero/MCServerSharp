using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Network.Packets.ClientPackets.Login {
	public class PacketLoginPluginResponse : IClientPacket {
		public State PacketState => State.Login;

		public byte PacketId => 2;

		public VarInt MessageID;
		public string Channel;
		public byte[] Data;

		public IClientPacket Parse(Span<byte> buffer) {
			var l = buffer.ReadVarInt(out MessageID);
			l += buffer[l..].GetString(out Channel);
			Data = buffer[l..].ToArray();
			return this;
		}

		public IPacket CreateInstance() => new PacketLoginPluginResponse();

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
	}
}
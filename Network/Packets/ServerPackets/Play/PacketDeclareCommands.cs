using MCServerSharp.Commands;
using System;

namespace MCServerSharp.Network.Packets.ServerPackets.Play {
	public class PacketDeclareCommands : IServerPacket {
		public State PacketState => State.Play;

		public byte PacketId => 16;

		public Span<byte> Bytes => CommandNode.DeclareCommandsBytes;

		public IPacket CreateInstance() => new PacketDeclareCommands();

		public IPacket DeepClone() => new PacketDeclareCommands();
	}
}
using System;
using System.Reflection;

namespace MCServerSharp.Network.Packets.ServerPackets {
	public interface IServerPacket : IPacket {

		public static IServerPacket[] StatusPackets = new IServerPacket[256];
		public static IServerPacket[] LoginPackets = new IServerPacket[256];
		public static IServerPacket[] PlayPackets = new IServerPacket[256];

		/// <summary>
		/// Initialize ServerPackets
		/// </summary>
		static IServerPacket() {
			foreach (var t in Assembly.GetExecutingAssembly().GetExportedTypes())
				if (t.IsAssignableTo(typeof(IServerPacket)) && !t.IsAbstract)
					RegisterPacket(Activator.CreateInstance(t) as IServerPacket);
		}
		/// <summary>
		/// Get bytes of packet to send
		/// </summary>
		public abstract Span<byte> Bytes { get; }

		/// <summary>
		/// Register a ServerPacket
		/// </summary>
		public static void RegisterPacket(IServerPacket p) {
			switch (p.PacketState) {
				case State.Handshaking:
					throw new Exception("Wrong packet state: " + p.PacketState.ToString());
				case State.Status:
					StatusPackets[p.PacketId] = p;
					break;
				case State.Login:
					LoginPackets[p.PacketId] = p;
					break;
				case State.Play:
					PlayPackets[p.PacketId] = p;
					break;
				default:
					throw new Exception("Unknown packet state: " + p.PacketState.ToString());
			}
		}
	}
}
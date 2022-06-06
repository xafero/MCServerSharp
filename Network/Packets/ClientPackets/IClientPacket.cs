using MCServerSharp.Data.Utils;
using System;
using System.Reflection;

namespace MCServerSharp.Network.Packets.ClientPackets {
	public interface IClientPacket : IPacket {

		public static IClientPacket[] HandshakingDefaultPackets = new IClientPacket[256];
		public static IClientPacket[] StatusDefaultPackets = new IClientPacket[256];
		public static IClientPacket[] LoginDefaultPackets = new IClientPacket[256];
		public static IClientPacket[] PlayDefaultPackets = new IClientPacket[256];

		/// <summary>
		/// Initialize ClientPackets
		/// </summary>
		static IClientPacket() {
			foreach (var t in Assembly.GetExecutingAssembly().GetExportedTypes())
				if (t.IsAssignableTo(typeof(IClientPacket)) && !t.IsAbstract)
					RegisterPacket(Activator.CreateInstance(t) as IClientPacket);
		}

		/// <summary>
		/// Register a ClientPacket
		/// </summary>
		public static void RegisterPacket(IClientPacket p) {
			switch (p.PacketState) {
				case State.Handshaking:
					HandshakingDefaultPackets[p.PacketId] = p;
					break;
				case State.Status:
					StatusDefaultPackets[p.PacketId] = p;
					break;
				case State.Login:
					LoginDefaultPackets[p.PacketId] = p;
					break;
				case State.Play:
					PlayDefaultPackets[p.PacketId] = p;
					break;
				default:
					throw new Exception("Unknown packet state: " + p.PacketState.ToString());
			}
		}

		public static unsafe IClientPacket GetPacket(Span<byte> data, State state) {
			var il = data.ReadVarInt(out int id);
			var p = state switch {
				State.Handshaking => HandshakingDefaultPackets[id],
				State.Status => StatusDefaultPackets[id],
				State.Login => LoginDefaultPackets[id],
				State.Play => PlayDefaultPackets[id],
				_ => null
			};
			if (p?.CreateInstance() is IClientPacket packet)
				return packet.Parse(data[il..]);
			return null;
		}

		public IClientPacket Parse(Span<byte> buffer);
	}
}
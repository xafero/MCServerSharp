using MCServerSharp.Network;
using System;
using static MCServerSharp.Network.NetworkServer;

namespace MCServerSharp.Events {
	public class EventsFactory {
		public readonly Server Server;

		/// <summary>
		/// Triggered when closing server
		/// </summary>
		public Action OnServerClose;
		/// <summary>
		/// Triggered when a client connected
		/// </summary>
		public AcceptEventHandler OnClientConnected;
		/// <summary>
		/// Triggered when a packet received from a client
		/// </summary>
		public NetworkClient.PacketReceivedEventHandler OnPacketReceived;

		public EventsFactory(Server server) {
			Server = server;
		}
	}
}

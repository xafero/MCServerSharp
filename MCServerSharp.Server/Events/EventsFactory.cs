using MCServerSharp.Network;
using System;
using System.Net.Sockets;
using MCServerSharp.Network.Packets.ClientPackets;
using static MCServerSharp.Network.NetworkServer;

namespace MCServerSharp.Events {
	public class EventsFactory : IEventsFactory {
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

		#region Interface
        void IEventsFactory.OnClientConnected(object sender, TcpClient tcp, ref bool cancel) 
            => OnClientConnected((NetworkServer)sender, tcp, ref cancel);
        void IEventsFactory.OnPacketReceived(object sender, object packet, ref bool cancel) 
            => OnPacketReceived((NetworkClient)sender, (IClientPacket)packet, ref cancel);
        #endregion
	}
}

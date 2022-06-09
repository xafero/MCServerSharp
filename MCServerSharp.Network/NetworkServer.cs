using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MCServerSharp.Network {
	public class NetworkServer : IDisposable {
		public readonly IServer Server;
		public readonly List<NetworkClient> Clients = new();
		public TcpListener Listener;
		protected readonly CancellationTokenSource Cancel = new();
		public NetworkServer(IPEndPoint BindTo, IServer Server) {
			this.Server = Server;
			Listener = new TcpListener(BindTo);
			Listener.Start();
			Task.Factory.StartNew(AcceptTask, Cancel.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
		}
		protected virtual void AcceptTask() {
			try {
				for (;;) {
					var cancel = false;
					var tcp = Listener.AcceptTcpClient();
					Server.EventsFactory.OnClientConnected(this, tcp, ref cancel);
					Accepted(this, tcp, ref cancel);
				}
			} catch (TaskCanceledException) {
			} catch (SocketException) {
				//TODO
			}
		}

		protected virtual void Accepted(NetworkServer sender, TcpClient client, ref bool cancelled) {
			if (cancelled) return;
			sender.Clients.Add(new NetworkClient(client, this));
		}

		public virtual void Dispose() {
			Cancel.Cancel();
			Listener.Stop();
			foreach (var c in Clients)
				c.Dispose();
			Clients.Clear();
		}

		public delegate void AcceptEventHandler(NetworkServer sender, TcpClient client, ref bool cancelled);
	}
}
using MCServerSharp.Data.Utils;
using MCServerSharp.Data.Entities;
using MCServerSharp.Network.Packets;
using MCServerSharp.Network.Packets.ClientPackets;
using MCServerSharp.Network.Packets.ServerPackets;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using MCServerSharp.Network.Packets.ClientPackets.Handshaking;
using MCServerSharp.Network.Packets.ClientPackets.Status;
using MCServerSharp.Network.Packets.ServerPackets.Status;
using MCServerSharp.Network.Packets.ClientPackets.Login;
using MCServerSharp.Network.Packets.ServerPackets.Login;
using MCServerSharp.Network.Packets.ServerPackets.Play;

namespace MCServerSharp.Network {
	public class NetworkClient : INetworkClient {
		public readonly NetworkServer NetworkServer;
		public State ConnectionState { get; protected set; } = State.Handshaking;
		public Player Player { get; protected internal set; }

		public event PacketReceivedEventHandler OnPacketReceived;

		protected readonly TcpClient Client;
		protected readonly NetworkStream Stream;
		protected readonly CancellationTokenSource Cancel = new();

		public NetworkClient(TcpClient client, NetworkServer server) {
			NetworkServer = server;
			Client = client;
			client.Client.ReceiveTimeout = 10000;
			client.Client.SendTimeout = 10000;
			Stream = client.GetStream();
			Task.Factory.StartNew(ReceiveTask, Cancel.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
		}

		public virtual async void SendAsync(IServerPacket packet) {
			await Task.Run(() => Send(packet));
		}

		public virtual void Send(IServerPacket packet) {
			var b = packet.Bytes;
			var i = new VarInt(b.Length).Buffer;
			var bi = new byte[i.Length + b.Length];
			Buffer.BlockCopy(i, 0, bi, 0, i.Length);
			b.CopyTo(bi.AsSpan()[i.Length..]);
			Stream.Write(bi, 0, bi.Length);
		}

		protected virtual void ReceiveTask() {
			for (;;) {
				try {
					var length = Stream.ReadVarInt();
					var buffer = Stream.ReadBytes(length);
					var cancel = false;
					var packet = IClientPacket.GetPacket(buffer, ConnectionState);
					OnPacketReceived(this, packet, ref cancel);
					NetworkServer.Server.EventsFactory.OnPacketReceived(this, packet, ref cancel);
					Received(this, packet, ref cancel);
				} catch (TaskCanceledException) {
					return;
				} catch (Exception ex) {
					Global.ServerInstance.LogError(ex.ToString());
					Disconnect(ex.Message);
				}
			}
		}

		protected virtual void Received(NetworkClient sender, IClientPacket packet, ref bool cancelled) {
			if (cancelled) return;
			switch (packet) {
				// HandShake
				case PacketHandshake p:
					ConnectionState = p.NextState;
					break;

				// Status
				case PacketRequest:
					SendAsync(new PacketResponse(null));
					break;
				case PacketPing p:
					SendAsync(p.GetPong());
					break;

				// Login
				case PacketLoginStart p:
					var uuid = UUID.Create();
					Player = new(p.UserName, uuid, this);
					SendAsync(new PacketLoginSuccess(uuid, p.UserName));

					break;
				case PacketEncryptionResponse p:
					//TODO
					break;
				case PacketLoginPluginResponse p:
					//TODO
					break;

				// Play
					//TODO
			}
		}

		public virtual void Disconnect(string reason = null) {
			try {
				if (ConnectionState == State.Login)
					SendAsync(new PacketLoginDisconnect(reason));
				if (ConnectionState == State.Play)
					SendAsync(new PacketPlayDisconnect(reason));
			} catch { };
			//TODO
			Dispose();
		}

		public virtual void Dispose() {
			try {
				NetworkServer.Clients.Remove(this);
				OnPacketReceived = null;
				Player = null;
				Cancel.Cancel();
				Stream.Close();
				Client.Close();
			} catch { }
		}

		public delegate void PacketReceivedEventHandler(NetworkClient sender, IClientPacket packet, ref bool cancelled);
	}
}
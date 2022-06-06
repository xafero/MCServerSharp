using MCServerSharp.Commands;
using MCServerSharp.Data.Entities;
using MCServerSharp.Data.Utils;
using MCServerSharp.Events;
using MCServerSharp.Network;
using MCServerSharp.Worlds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace MCServerSharp {
	/// <summary>
	/// A Minectaft Server implemented with C#
	/// </summary>
	public class Server : IDisposable {
		[DllImport("User32", EntryPoint = "SendMessage", CallingConvention = CallingConvention.Winapi)]
		protected static extern void SetIcon(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
		[DllImport("Kernel32", EntryPoint = "GetConsoleWindow", CallingConvention = CallingConvention.Winapi)]
		protected static extern IntPtr GetConsoleWindowHWND();

		/// <summary>
		/// Instance of server
		/// </summary>
		public static Server Instance;
		public static HttpClient Http = new();

		/// <summary>
		/// Game version of minecraft
		/// </summary>
		public readonly string GameVersion = "1.16.5";

		public readonly struct Options {
			/// <summary>
			/// IP which server bind to
			/// </summary>
			public readonly string IP;
			/// <summary>
			/// Port which server bind to
			/// </summary>
			public readonly ushort Port;
			/// <summary>
			/// Threshold of length of bytes whether to compress a packet
			/// </summary>
			public readonly int CompressionThreshold;
			/// <summary>
			/// Maximum number of players simultaneous online 
			/// </summary>
			public readonly int MaxPlayers;
			/// <summary>
			/// Whether to authenticate players with mojang
			/// </summary>
			public readonly bool OnlineMode;
			/// <summary>
			/// Max height to build block in worlds
			/// </summary>
			public readonly byte MaxBuildHeight;
			public Options(ushort port, string ip = "0.0.0.0", int compresstionThreshold = 256, int maxPlayers = 10, bool onlineMode = true, byte maxBuildHeight = 255) {
				IP = ip;
				Port = port;
				CompressionThreshold = compresstionThreshold;
				MaxPlayers = maxPlayers;
				OnlineMode = onlineMode;
				MaxBuildHeight = maxBuildHeight;
			}
		}
		/// <summary>
		/// Options of the server
		/// </summary>
		public readonly Options ServerOptions;
		/// <summary>
		/// Class handling network connections
		/// </summary>
		public readonly NetworkServer Network;
		/// <summary>
		/// Base64 string of binary data of server-icon.png
		/// </summary>
		public string ServerIconBase64;
		/// <summary>
		/// All events of this server are handled here
		/// </summary>
		public readonly EventsFactory EventsFactory;
		/// <summary>
		/// Logger to log to file
		/// </summary>
		protected readonly StreamWriter logger;

		/// <summary>
		/// Players in the server
		/// </summary>
		public readonly List<Player> Players = new();
		/// <summary>
		/// Worlds in the server
		/// </summary>
		public readonly List<World> Worlds = new();
		/// <summary>
		/// Operators of the server
		/// </summary>
		public readonly HashSet<UUID> Operators = new();

		/// <summary>
		/// Start a new instance of server
		/// </summary>
		public Server(string[] configs) {
			Instance = this;

			if (File.Exists(@"Logs\Log.txt")) File.Move(@"Logs\Log.txt", File.GetCreationTime(@"Logs\Log.txt").ToString("s").Replace(':', '.') + "_Log.txt");
			logger = new StreamWriter(File.Open(@"Logs\Log.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite));

			if (File.Exists("server-icon.png")) {
				Log("Loading server-icon.png");
				var b = File.ReadAllBytes("server-icon.png");
				ServerIconBase64 = Convert.ToBase64String(b); //For Server List
				var ms = new MemoryStream(b);
				var icon = new Bitmap(ms).GetHicon();
				SetIcon(GetConsoleWindowHWND(), 0x80, 0, icon); //Small Icon
				SetIcon(GetConsoleWindowHWND(), 0x80, 1, icon); //Large Icon
				ms.Close();
			}

			ServerOptions = new Options(25565);

			PluginManager.ReloadPlugins("plugins");

			CommandNode.BuildCommands();

			Worlds.Add(new World("world"));

			Network = new NetworkServer(new IPEndPoint(IPAddress.Parse(ServerOptions.IP), ServerOptions.Port), this);

			EventsFactory = new EventsFactory(this);

			for (;;)
				CommandNode.RunCommand(ConsoleExcutor.Instance, Console.ReadLine());
		}

		public static Server Run(string[] configs) {
			return new Server(configs);
		}

		#region Loggers
		/// <summary>
		/// Log to console and log file
		/// </summary>
		public static void Log(string text, ConsoleColor color = ConsoleColor.White) {
			var s = $"[{DateTime.Now:G}][Info]: {text}";
			Console.ForegroundColor = color;
			Console.WriteLine(s);
			Instance.logger.WriteLine(s);
		}
		/// <summary>
		/// Log warning to console and log file
		/// </summary>
		public static void LogWarning(string text, ConsoleColor color = ConsoleColor.Yellow) {
			var s = $"[{DateTime.Now:G}][Warning]: {text}";
			Console.ForegroundColor = color;
			Console.WriteLine(s);
			Instance.logger.WriteLine(s);
		}
		/// <summary>
		/// Log error to console and log file
		/// </summary>
		public static void LogError(string text, ConsoleColor color = ConsoleColor.Red) {
			var s = $"[{DateTime.Now:G}][Error]: {text}";
			Console.ForegroundColor = color;
			Console.Error.WriteLine(s);
			Instance.logger.WriteLine(s);
		}
		#endregion Loggers

		/// <summary>
		/// Closing the server
		/// </summary>
		public virtual void Close() {
			EventsFactory.OnServerClose();
			Dispose();
		}

		public virtual void Dispose() {
			Network.Dispose();
			logger.Close();
			Instance = null;
		}
	}
}

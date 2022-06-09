using MCServerSharp.Data.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MCServerSharp.Network.Packets.ServerPackets.Status {
	public class PacketResponse : IServerPacket {
		public State PacketState => State.Status;
		public byte PacketId => 0;
		public Span<byte> Bytes => JSONResponse.AsSpan().GetBytes();

		public string JSONResponse;

		#nullable enable
		public PacketResponse(string? JSONResponse) {
			if (JSONResponse is null) {
				var server = Global.ServerInstance;
				this.JSONResponse = GenerateText(server.GameVersion, IPacket.LastestProtocolVersion, server.MaxPlayers, server.PlayersCount, Array.Empty<string>(), "Powered By MCServerSharp", server.ServerIconBase64);
			} else
				this.JSONResponse = JSONResponse;
		}

		/*
		Example:
		{
			"version": {
				"name": "1.8.7",
				"protocol": 47
			},
			"players": {
				"max": 100,
				"online": 5,
				"sample": [
					{
						"name": "thinkofdeath",
						"id": "4566e69f-c907-48ee-8d71-d7ba5aa00d20"
					}
				]
			},
			"description": {
				"text": "Hello world"
			},
			"favicon": "data:image/png;base64,<data>"
		}
		*/

		public static string GenerateText(string GameVersion, int ProtocolVersion, int MaxPlayers, int OnlineCount, string[]? SampleTexts = null, string Description = "Powered By MCServerSharp", string? ServerIconBase64 = null) {
			var l = new List<KeyValuePair<string, UUID>>(SampleTexts?.Length ?? 0);
			if (SampleTexts != null)
				foreach (var s in SampleTexts)
					l.Add(new(s, new UUID()));
			return GenerateText(GameVersion, ProtocolVersion, MaxPlayers, OnlineCount, l, Description, ServerIconBase64);
		}

		public static string GenerateText(string GameVersion, int ProtocolVersion, int MaxPlayers, int OnlineCount, IEnumerable<KeyValuePair<string, UUID>> Players, string Description = "Powered By MCServerSharp", string? ServerIconBase64 = null) {
			var js = new Utf8JsonWriter(new MemoryStream());
			js.WriteStartObject();

			js.WriteStartObject("version");
			js.WriteString("name", "MCSS " + GameVersion);
			js.WriteNumber("protocol", ProtocolVersion);
			js.WriteEndObject();

			js.WriteStartObject("players");
			js.WriteNumber("max", MaxPlayers);
			js.WriteNumber("online", OnlineCount);

			js.WriteStartArray("sample");
			foreach (var (s, u) in Players) {
				js.WriteStartObject();
				js.WriteString(s, u.ToString());
				js.WriteEndObject();
			}
			js.WriteEndObject();

			js.WriteStartObject("description");
			js.WriteString("text", Description);
			js.WriteEndObject();

			if (ServerIconBase64 != null)
				js.WriteString("favicon", "data:image/png;base64," + ServerIconBase64);

			js.WriteEndObject();
			#nullable disable
			return js.ToString();
		}

		public IPacket DeepClone() => MemberwiseClone() as IPacket;
		public IPacket CreateInstance() => new PacketResponse("");
	}
}
using MCServerSharp.Data.Items.Inventories;
using MCServerSharp.Data.Utils;
using MCServerSharp.Network;
using System.Collections.Generic;

namespace MCServerSharp.Data.Entities {
	public class Player : Entity {
		/// <summary>
		/// NetworkClient of the player's connection
		/// </summary>
		public readonly NetworkClient Network;
		/// <summary>
		/// The player's account name (usually gotten from mojang)
		/// </summary>
		public readonly string AccountName;
		/// <summary>
		/// The player's inventory
		/// </summary>
		public readonly PlayerInventory Inventory;
		public readonly HashSet<string> Permissions;

		public Player(string name, UUID uuid, NetworkClient network) : base(uuid) {
			AccountName = name;
			DisplayName = name;
			Network = network;
		}

		public override bool IsOp => Server.Instance.Operators.Contains(Uuid);
		public override bool HasPermission(string permission) {
			if (IsOp) return true;
			return Permissions.Contains(permission);
		}
		public override void SendMessage(string message) {
			// TODO
		}
	}
}

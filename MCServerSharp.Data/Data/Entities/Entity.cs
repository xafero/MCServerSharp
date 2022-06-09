using MCServerSharp.Data.NBTs;
using MCServerSharp.Data.Utils;

namespace MCServerSharp.Data.Entities {
	public abstract class Entity : ICommandExecutor, INBTTarget {
		/// <summary>
		/// Universally Unique Identifier of the entity
		/// </summary>
		public readonly UUID Uuid;
		/// <summary>
		/// Location at where the entity is
		/// </summary>
		public virtual Location Location { get; set; }
		/// <summary>
		/// Nickname of the entity
		/// </summary>
		public virtual string DisplayName { get; set; }

		public Entity() {
			Uuid = UUID.Create();
		}

		public Entity(UUID uuid) {
			Uuid = uuid;
		}

		public Entity(Location location) {
			Uuid = UUID.Create();
			Location = location;
		}

		public Entity(Location location, UUID uuid) {
			Uuid = uuid;
			Location = location;
		}

		public virtual bool IsOp => true;
		
		public virtual bool HasPermission(string permission) => true;

		public virtual void SendMessage(string message) {
		}
	}
}

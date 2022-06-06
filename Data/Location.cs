using MCServerSharp.Worlds;
using System;
using System.Runtime.Serialization;

namespace MCServerSharp.Data {
	/// <summary>
	/// Position and rotation
	/// </summary>
	[Serializable]
	public struct Location : ISerializable {
		public World World;
		public int X;
		public int Y;
		public int Z;
		public int Yaw;
		public int Pitch;

		public Location(World world, int x, int y, int z, int yaw = 0, int pitch = 0) {
			World = world;
			X = x;
			Y = y;
			Z = z;
			Yaw = yaw;
			Pitch = pitch;
		}

		private Location(SerializationInfo info, StreamingContext context) {
			World = World.GetWorld(info.GetString("World"));
			X = info.GetInt32("X");
			Y = info.GetInt32("Y");
			Z = info.GetInt32("Z");
			Yaw = info.GetInt32("Yaw");
			Pitch = info.GetInt32("Pitch");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("World", World.Name);
			info.AddValue("X", X);
			info.AddValue("Y", Y);
			info.AddValue("Z", Z);
			info.AddValue("Yaw", Yaw);
			info.AddValue("Pitch", Pitch);
		}

		public static bool operator ==(Location x, Location y) {
			return x.Equals(y);
		}

		public static bool operator !=(Location x, Location y) {
			return !x.Equals(y);
		}
	}
}

using System;
using System.Runtime.InteropServices;

namespace MCServerSharp.Data.Utils {
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 12)]
	public struct Vector3 {
		public int X;
		public int Y;
		public int Z;

		public Vector3(int x, int y, int z) {
			X = x;
			Y = y;
			Z = z;
		}
	}
}
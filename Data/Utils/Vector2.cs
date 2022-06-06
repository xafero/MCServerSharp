using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MCServerSharp.Data.Utils {
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 8)]
	public struct Vector2 {
		public int X;
		public int Y;

		public Vector2(int x, int y) {
			X = x;
			Y = y;
		}

		public class Comparer : IComparer<Vector2> {
			public static Comparer Instance = new Comparer();
			public int Compare(Vector2 x, Vector2 y) {
				if (x.Y > y.Y) return 1;
				else if (x.Y < y.Y) return -1;
				else if(x.X > y.X) return 1;
				else if (x.X < y.X) return -1;
				else return 0;
			}
		}
	}
}
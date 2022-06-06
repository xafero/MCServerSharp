using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MCServerSharp.Data.Utils {

	/// <summary>
	/// Universally Unique Identifier
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	public struct UUID {
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] Bytes;
		/// <summary>
		/// Initialize a UUID from a byte array
		/// </summary>
		/// <param name="bytes">byte array of length 16</param>
		public UUID(byte[] bytes) {
			if (bytes.Length != 16)
				throw new ArgumentException("The length of UUID bytes must be 16", nameof(bytes));
			Bytes = bytes;
		}
		/// <summary>
		/// Create a random UUID
		/// </summary>
		public static UUID Create() => (UUID)Guid.NewGuid();
		/// <summary>
		/// Initialize a UUID from a UUID string of length 16
		/// </summary>
		/// <param name="str">UUID string with the format of "FFFF-FF-FF-FF-FFFFFF"</param>
		public static UUID FromString(in ReadOnlySpan<char> str) {
			if (str.Length != 36)
				throw new ArgumentException("The length of UUID string must be 36", nameof(str));
			var b = new byte[16];
			str[0].HexValue(str[1], out b[0]);
			str[2].HexValue(str[3], out b[1]);
			str[4].HexValue(str[5], out b[2]);
			str[6].HexValue(str[7], out b[3]);
			str[9].HexValue(str[10], out b[4]);
			str[11].HexValue(str[12], out b[5]);
			str[14].HexValue(str[15], out b[6]);
			str[16].HexValue(str[17], out b[7]);
			str[19].HexValue(str[20], out b[8]);
			str[21].HexValue(str[22], out b[9]);
			str[24].HexValue(str[25], out b[10]);
			str[26].HexValue(str[27], out b[11]);
			str[28].HexValue(str[29], out b[12]);
			str[30].HexValue(str[31], out b[13]);
			str[32].HexValue(str[33], out b[14]);
			str[34].HexValue(str[35], out b[15]);
			return new UUID(b);
		}
		/// <summary>
		/// Get the version of a UUID
		/// </summary>
		public int GetVersion() => Bytes[9] >> 4;

		/// <summary>
		/// Convert a UUID to a windows system Guid
		/// </summary>
		public static explicit operator Guid(UUID v) {
			var b = v.Bytes;
			Array.Reverse(b, 0, 4);
			Array.Reverse(b, 4, 2);
			Array.Reverse(b, 6, 2);
			return new Guid(b);
		}
		/// <summary>
		/// Convert a windows system Guid to a UUID
		/// </summary>
		public static explicit operator UUID(Guid v) {
			var b = v.ToByteArray();
			Array.Reverse(b, 0, 4);
			Array.Reverse(b, 4, 2);
			Array.Reverse(b, 6, 2);
			return new UUID(b);
		}

		/// <returns>ToString().GetHashCode()</returns>
		public override int GetHashCode() {
			return ToString().GetHashCode();
		}
		/// <summary>
		/// Get a UUID string with the format of "FFFF-FF-FF-FF-FFFFFF"
		/// </summary>
		public unsafe override string ToString() {
			var str = new string('\0', 36);
			fixed (char *c = str) {
				Bytes[0].ToHex(out c[0], out c[1]);
				Bytes[1].ToHex(out c[2], out c[3]);
				Bytes[2].ToHex(out c[4], out c[5]);
				Bytes[3].ToHex(out c[6], out c[7]);
				c[8] = '-';
				Bytes[4].ToHex(out c[9], out c[10]);
				Bytes[5].ToHex(out c[11], out c[12]);
				c[13] = '-';
				Bytes[6].ToHex(out c[14], out c[15]);
				Bytes[7].ToHex(out c[16], out c[17]);
				c[18] = '-';
				Bytes[8].ToHex(out c[19], out c[20]);
				Bytes[9].ToHex(out c[21], out c[22]);
				c[23] = '-';
				Bytes[10].ToHex(out c[24], out c[25]);
				Bytes[11].ToHex(out c[26], out c[27]);
				Bytes[12].ToHex(out c[28], out c[29]);
				Bytes[13].ToHex(out c[30], out c[31]);
				Bytes[14].ToHex(out c[32], out c[33]);
				Bytes[15].ToHex(out c[34], out c[35]);
			}
			return str;
		}
	}
}

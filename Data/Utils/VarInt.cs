using System;

namespace MCServerSharp.Data.Utils {
	[Serializable]
	public struct VarInt : IEquatable<VarInt>, ICloneable {
		[NonSerialized]
		public byte[] Buffer;
		public int Value {
			get {
				var value = 0;
				for (var i = 0; i < Buffer.Length; ++i) {
					var b = Buffer[i];
					value |= (b & 0x7F) << 7 * i;
				}
				return value;
			}
			set {
				var v = (uint)value; // Support negative numbers
				if (v < 0x80U)
					Buffer = new byte[1];
				else if (v < 0x4000U)
					Buffer = new byte[2];
				else if (v < 0x200000U)
					Buffer = new byte[3];
				else if (v < 0x10000000U)
					Buffer = new byte[4];
				else
					Buffer = new byte[5];
				int i;
				for (i = 0; i < Buffer.Length - 1; ++i) {
					Buffer[i] = (byte)(v | 0x80);
					v >>= 7;
				}
				Buffer[i] = (byte)v;
			}
		}
		public VarInt(int value) {
			Buffer = null;
			Value = value;
		}
		public VarInt(byte[] buffer) {
			if (buffer.Length > 5 || buffer.Length == 5 && buffer[4] > 0xF)
				throw new ArgumentOutOfRangeException(nameof(buffer), "Int value out of range");
			Buffer = buffer;
		}
		public bool Equals(VarInt other) => Buffer == other.Buffer;
		public override bool Equals(object obj) {
			if (obj is VarLong vl)
				try {
					return Equals((VarInt)vl);
				} catch {
					return false;
				}
			if (obj is VarInt vi)
				return Equals(vi);
			return false;
		}
		public static bool operator ==(VarInt x, VarInt y) => x.Equals(y);
		public static bool operator !=(VarInt x, VarInt y) => !x.Equals(y);
		public static implicit operator VarInt(int v) => new(v);
		public static implicit operator int(VarInt v) => v.Value;
		public override int GetHashCode() => this;
		public override string ToString() => Value.ToString();
		public VarInt Clone() => new(Buffer);
		object ICloneable.Clone() => Clone();
	}
}
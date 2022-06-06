using System;

namespace MCServerSharp.Data.Utils {
	[Serializable]
#pragma warning disable CS0659 // 類型會覆寫 Object.Equals(object o)，但不會覆寫 Object.GetHashCode()
#pragma warning disable CS0661 // 類型會定義運算子 == 或運算子 !=，但不會覆寫 Object.GetHashCode()
	public struct VarLong : IEquatable<VarLong>, ICloneable {
		[NonSerialized]
		public byte[] Buffer;
		public long Value {
			get {
				var value = 0;
				for (var i = 0; i < Buffer.Length; ++i) {
					var b = Buffer[i];
					value |= (b & 0x7F) << 7 * i;
				}
				return value;
			}
			set {
				var v = (ulong)value; // Support negative numbers
				if (v < 0x80)
					Buffer = new byte[1];
				else if (v < 0x4000UL)
					Buffer = new byte[2];
				else if (v < 0x200000UL)
					Buffer = new byte[3];
				else if (v < 0x10000000UL)
					Buffer = new byte[4];
				else if (v < 0x800000000UL)
					Buffer = new byte[5];
				else if (v < 0x40000000000UL)
					Buffer = new byte[6];
				else if (v < 0x2000000000000UL)
					Buffer = new byte[7];
				else
					Buffer = new byte[8];
				int i;
				for (i = 0; i < Buffer.Length - 1; ++i) {
					Buffer[i] = (byte)(v | 0x80);
					v >>= 7;
				}
				Buffer[i] = (byte)v;
			}
		}
		public VarLong(long value) {
			Buffer = null;
			Value = value;
		}
		public VarLong(byte[] buffer) => Buffer = buffer;
		public bool Equals(VarLong other) => Buffer == other.Buffer;
		public override bool Equals(object obj) {
			if (obj is VarInt vi)
				return Equals(vi);
			if (obj is VarLong vl)
				return Equals(vl);
			return false;
		}
		public static bool operator ==(VarLong x, VarLong y) => x.Equals(y);
		public static bool operator !=(VarLong x, VarLong y) => !x.Equals(y);
		public static implicit operator VarLong(long v) => new(v);
		public static implicit operator long(VarLong v) => v.Value;
		public static implicit operator VarLong(VarInt v) => new(v.Buffer);
		public static explicit operator VarInt(VarLong v) => new(v.Buffer);
		public override string ToString() => Value.ToString();
		public VarInt Clone() => new(Buffer);
		object ICloneable.Clone() => Clone();
	}
}
using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserFloat : Parser {
		/// <summary>
		/// If not specified, defaults to -Float.MAX_VALUE (≈ 3.4028235E38)
		/// </summary>
		public float? Min;
		/// <summary>
		/// If not specified, defaults to Float.MAX_VALUE (≈ 3.4028235E38)
		/// </summary>
		public float? Max;
		public override string Identifier => "brigadier:float";
		public override byte[] Bytes {
			get {
				if (Min.HasValue && Max.HasValue) {
					var b = new byte[9];
					Min.Value.GetBytes().CopyTo(b);
					Max.Value.GetBytes().CopyTo(b);
					return b;
				} else if (Min.HasValue) {
					var b = new byte[5];
					Min.Value.GetBytes().CopyTo(b);
					return b;
				} else if (Max.HasValue) {
					var b = new byte[5];
					Max.Value.GetBytes().CopyTo(b);
					return b;
				} else {
					return Array.Empty<byte>();
				}
			}
		}
		public ParserFloat() {
		}
		public ParserFloat(float? Min, float? Max) {
			this.Min = Min;
			this.Max = Max;
		}
	}
}
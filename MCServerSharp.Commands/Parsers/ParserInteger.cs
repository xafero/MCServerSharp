using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserInteger : Parser {
		/// <summary>
		/// If not specified, defaults to Integer.MIN_VALUE (-2147483648)
		/// </summary>
		public int? Min;
		/// <summary>
		/// If not specified, defaults to Integer.MAX_VALUE (2147483647)
		/// </summary>
		public int? Max;
		public override string Identifier => "brigadier:integer";
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
		public ParserInteger() {
		}
		public ParserInteger(int? Min, int? Max) {
			this.Min = Min;
			this.Max = Max;
		}
	}
}
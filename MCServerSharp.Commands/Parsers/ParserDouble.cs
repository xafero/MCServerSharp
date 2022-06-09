using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserDouble : Parser {
		/// <summary>
		/// If not specified, defaults to -Double.MAX_VALUE (≈ -1.7976931348623157E307)
		/// </summary>
		public double? Min;
		/// <summary>
		/// If not specified, defaults to Double.MAX_VALUE (≈ 1.7976931348623157E307)
		/// </summary>
		public double? Max;
		public override string Identifier => "brigadier:double";
		public override byte[] Bytes {
			get {
				if (Min.HasValue && Max.HasValue) {
					var b = new byte[17] ;
					Min.Value.GetBytes().CopyTo(b);
					Max.Value.GetBytes().CopyTo(b);
					return b;
				} else if (Min.HasValue) {
					var b = new byte[9];
					Min.Value.GetBytes().CopyTo(b);
					return b;
				} else if (Max.HasValue) {
					var b = new byte[9];
					Max.Value.GetBytes().CopyTo(b);
					return b;
				} else {
					return Array.Empty<byte>();
				}
			}
		}
		public ParserDouble() {
		}
		public ParserDouble(double? Min, double? Max) {
			this.Min = Min;
			this.Max = Max;
		}
	}
}
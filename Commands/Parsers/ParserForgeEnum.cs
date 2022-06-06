using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserForgeEnum : Parser {
		/// <summary>
		/// Enum Class to use
		/// </summary>
		public string ClassName;
		public override string Identifier => "forge:enum";
		public override byte[] Bytes => ClassName.AsSpan().GetBytes();
		public ParserForgeEnum(string ClassName) {
			if (ClassName is null)
				throw new ArgumentNullException(nameof(ClassName));
			this.ClassName = ClassName;
		}
	}
}
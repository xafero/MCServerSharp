using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserBool : Parser {
		public static ParserBool Instance = new();
		public override string Identifier => "brigadier:bool";
		protected ParserBool() {
		}
	}
}
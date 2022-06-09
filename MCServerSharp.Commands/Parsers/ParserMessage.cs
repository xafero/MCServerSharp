namespace MCServerSharp.Commands.Parsers {
	public class ParserMessage : Parser {
		public static ParserMessage Instance = new();
		public override string Identifier => "minecraft:message";
		protected ParserMessage() {
		}
	}
}
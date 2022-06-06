namespace MCServerSharp.Commands.Parsers {
	public class ParserColor : Parser {
		public static ParserColor Instance = new();
		public override string Identifier => "minecraft:color";
		protected ParserColor() {
		}
	}
}
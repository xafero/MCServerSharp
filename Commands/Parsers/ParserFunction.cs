namespace MCServerSharp.Commands.Parsers {
	public class ParserFunction : Parser {
		public static ParserFunction Instance = new();
		public override string Identifier => "minecraft:function";
		protected ParserFunction() {
		}
	}
}
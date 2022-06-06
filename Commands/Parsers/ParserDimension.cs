namespace MCServerSharp.Commands.Parsers {
	public class ParserDimension : Parser {
		public static ParserDimension Instance = new();
		public override string Identifier => "minecraft:dimension";
		protected ParserDimension() {
		}
	}
}
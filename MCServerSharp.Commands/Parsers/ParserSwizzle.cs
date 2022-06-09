namespace MCServerSharp.Commands.Parsers {
	public class ParserSwizzle : Parser {
		public static ParserSwizzle Instance = new();
		public override string Identifier => "minecraft:swizzle";
		protected ParserSwizzle() {
		}
	}
}
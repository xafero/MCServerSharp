namespace MCServerSharp.Commands.Parsers {
	public class ParserForgeModid : Parser {
		public static ParserForgeModid Instance = new();
		public override string Identifier => "forge:modid";
		protected ParserForgeModid() {
		}
	}
}
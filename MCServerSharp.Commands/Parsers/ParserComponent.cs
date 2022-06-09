namespace MCServerSharp.Commands.Parsers {
	public class ParserComponent : Parser {
		public static ParserComponent Instance = new();
		public override string Identifier => "minecraft:component";
		protected ParserComponent() {
		}
	}
}
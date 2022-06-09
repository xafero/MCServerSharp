namespace MCServerSharp.Commands.Parsers {
	public class ParserEntityAnchor : Parser {
		public static ParserEntityAnchor Instance = new();
		public override string Identifier => "minecraft:entity_anchor";
		protected ParserEntityAnchor() {
		}
	}
}
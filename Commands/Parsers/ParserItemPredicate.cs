namespace MCServerSharp.Commands.Parsers {
	public class ParserItemPredicate : Parser {
		public static ParserItemPredicate Instance = new();
		public override string Identifier => "minecraft:item_predicate";
		protected ParserItemPredicate() {
		}
	}
}
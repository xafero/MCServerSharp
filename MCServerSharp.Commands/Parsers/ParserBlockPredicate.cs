namespace MCServerSharp.Commands.Parsers {
	public class ParserBlockPredicate : Parser {
		public static ParserBlockPredicate Instance = new();
		public override string Identifier => "minecraft:block_predicate";
		protected ParserBlockPredicate() {
		}
	}
}
namespace MCServerSharp.Commands.Parsers {
	public class ParserObjectiveCriteria : Parser {
		public static ParserObjectiveCriteria Instance = new();
		public override string Identifier => "minecraft:objective_criteria";
		protected ParserObjectiveCriteria() {
		}
	}
}
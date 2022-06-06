namespace MCServerSharp.Commands.Parsers {
	public class ParserEntitySummon : Parser {
		public static ParserEntitySummon Instance = new();
		public override string Identifier => "minecraft:entity_summon";
		protected ParserEntitySummon() {
		}
	}
}
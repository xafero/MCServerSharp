namespace MCServerSharp.Commands.Parsers {
	public class ParserObjective : Parser {
		public static ParserObjective Instance = new();
		public override string Identifier => "minecraft:objective";
		protected ParserObjective() {
		}
	}
}
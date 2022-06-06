namespace MCServerSharp.Commands.Parsers {
	public class ParserColumnPos : Parser {
		public static ParserColumnPos Instance = new();
		public override string Identifier => "minecraft:column_pos";
		protected ParserColumnPos() {
		}
	}
}
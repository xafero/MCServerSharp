namespace MCServerSharp.Commands.Parsers {
	public class ParserBlockPos : Parser {
		public static ParserBlockPos Instance = new();
		public override string Identifier => "minecraft:block_pos";
		protected ParserBlockPos() {
		}
	}
}
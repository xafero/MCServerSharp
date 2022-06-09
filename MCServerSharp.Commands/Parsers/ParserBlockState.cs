namespace MCServerSharp.Commands.Parsers {
	public class ParserBlockState : Parser {
		public static ParserBlockState Instance = new();
		public override string Identifier => "minecraft:block_state";
		protected ParserBlockState() {
		}
	}
}
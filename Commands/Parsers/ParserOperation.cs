namespace MCServerSharp.Commands.Parsers {
	public class ParserOperation : Parser {
		public static ParserOperation Instance = new();
		public override string Identifier => "minecraft:operation";
		protected ParserOperation() {
		}
	}
}
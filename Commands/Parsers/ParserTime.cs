namespace MCServerSharp.Commands.Parsers {
	public class ParserTime : Parser {
		public static ParserTime Instance = new();
		public override string Identifier => "minecraft:time";
		protected ParserTime() {
		}
	}
}
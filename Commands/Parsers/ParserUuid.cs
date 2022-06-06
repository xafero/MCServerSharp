namespace MCServerSharp.Commands.Parsers {
	public class ParserUuid : Parser {
		public static ParserUuid Instance = new();
		public override string Identifier => "minecraft:uuid";
		protected ParserUuid() {
		}
	}
}
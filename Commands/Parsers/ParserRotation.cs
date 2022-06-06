namespace MCServerSharp.Commands.Parsers {
	public class ParserRotation : Parser {
		public static ParserRotation Instance = new();
		public override string Identifier => "minecraft:rotation";
		protected ParserRotation() {
		}
	}
}
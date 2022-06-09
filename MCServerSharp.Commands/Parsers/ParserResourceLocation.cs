namespace MCServerSharp.Commands.Parsers {
	public class ParserResourceLocation : Parser {
		public static ParserResourceLocation Instance = new();
		public override string Identifier => "minecraft:resource_location";
		protected ParserResourceLocation() {
		}
	}
}
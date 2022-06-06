namespace MCServerSharp.Commands.Parsers {
	public class ParserNbtTag : Parser {
		public static ParserNbtTag Instance = new();
		public override string Identifier => "minecraft:nbt_tag";
		protected ParserNbtTag() {
		}
	}
}
namespace MCServerSharp.Commands.Parsers {
	public class ParserNbtPath : Parser {
		public static ParserNbtPath Instance = new();
		public override string Identifier => "minecraft:nbt_path";
		protected ParserNbtPath() {
		}
	}
}
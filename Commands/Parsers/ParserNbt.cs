namespace MCServerSharp.Commands.Parsers {
	public class ParserNbt : Parser {
		public static ParserNbt Instance = new();
		public override string Identifier => "minecraft:nbt";
		protected ParserNbt() {
		}
	}
}
namespace MCServerSharp.Commands.Parsers {
	public class ParserItemStack : Parser {
		public static ParserItemStack Instance = new();
		public override string Identifier => "minecraft:item_stack";
		protected ParserItemStack() {
		}
	}
}
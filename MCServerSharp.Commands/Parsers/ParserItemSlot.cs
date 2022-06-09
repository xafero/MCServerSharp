namespace MCServerSharp.Commands.Parsers {
	public class ParserItemSlot : Parser {
		public static ParserItemSlot Instance = new();
		public override string Identifier => "minecraft:item_slot";
		protected ParserItemSlot() {
		}
	}
}
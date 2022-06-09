namespace MCServerSharp.Commands.Parsers {
	public class ParserItemEnchantment : Parser {
		public static ParserItemEnchantment Instance = new();
		public override string Identifier => "minecraft:item_enchantment";
		protected ParserItemEnchantment() {
		}
	}
}
namespace MCServerSharp.Commands.Parsers {
	public class ParserNbtCompoundTag : Parser {
		public static ParserNbtCompoundTag Instance = new();
		public override string Identifier => "minecraft:nbt_compound_tag";
		protected ParserNbtCompoundTag() {
		}
	}
}
namespace MCServerSharp.Commands.Parsers {
	public class ParserFloatRange : Parser {
		public static ParserFloatRange Instance = new();
		public override string Identifier => "minecraft:float_range";
		protected ParserFloatRange() {
		}
	}
}
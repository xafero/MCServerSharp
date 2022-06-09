namespace MCServerSharp.Commands.Parsers {
	public class ParserVec2 : Parser {
		public static ParserVec2 Instance = new();
		public override string Identifier => "minecraft:vec2";
		protected ParserVec2() {
		}
	}
}
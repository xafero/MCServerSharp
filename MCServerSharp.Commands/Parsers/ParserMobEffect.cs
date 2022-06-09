namespace MCServerSharp.Commands.Parsers {
	public class ParserMobEffect : Parser {
		public static ParserMobEffect Instance = new();
		public override string Identifier => "minecraft:mob_effect";
		protected ParserMobEffect() {
		}
	}
}
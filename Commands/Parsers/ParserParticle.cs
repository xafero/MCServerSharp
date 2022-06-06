namespace MCServerSharp.Commands.Parsers {
	public class ParserParticle : Parser {
		public static ParserParticle Instance = new();
		public override string Identifier => "minecraft:particle";
		protected ParserParticle() {
		}
	}
}
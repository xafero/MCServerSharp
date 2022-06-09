namespace MCServerSharp.Commands.Parsers {
	public class ParserGameProfile : Parser {
		public static ParserGameProfile Instance = new();
		public override string Identifier => "minecraft:game_profile";
		protected ParserGameProfile() {
		}
	}
}
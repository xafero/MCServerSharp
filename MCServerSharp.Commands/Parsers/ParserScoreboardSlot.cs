namespace MCServerSharp.Commands.Parsers {
	public class ParserScoreboardSlot : Parser {
		public static ParserScoreboardSlot Instance = new();
		public override string Identifier => "minecraft:scoreboard_slot";
		protected ParserScoreboardSlot() {
		}
	}
}
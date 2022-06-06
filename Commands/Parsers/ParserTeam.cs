namespace MCServerSharp.Commands.Parsers {
	public class ParserTeam : Parser {
		public static ParserTeam Instance = new();
		public override string Identifier => "minecraft:team";
		protected ParserTeam() {
		}
	}
}
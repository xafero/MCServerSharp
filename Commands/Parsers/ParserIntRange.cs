namespace MCServerSharp.Commands.Parsers {
	public class ParserIntRange : Parser {
		public static ParserIntRange Instance = new();
		public override string Identifier => "minecraft:int_range";
		protected ParserIntRange() {
		}
	}
}
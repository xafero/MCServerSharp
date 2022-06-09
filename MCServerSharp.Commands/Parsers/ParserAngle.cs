namespace MCServerSharp.Commands.Parsers {
	public class ParserAngle : Parser {
		public static ParserAngle Instance = new();
		public override string Identifier => "minecraft:angle";
		protected ParserAngle() {
		}
		public override bool Verify(string str) {
			return double.TryParse(str, out _);
		}
	}
}
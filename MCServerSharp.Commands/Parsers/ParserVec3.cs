namespace MCServerSharp.Commands.Parsers {
	public class ParserVec3 : Parser {
		public static ParserVec3 Instance = new();
		public override string Identifier => "minecraft:vec3";
		protected ParserVec3() {
		}
	}
}
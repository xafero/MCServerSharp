namespace MCServerSharp.Commands.Parsers {
	public class ParserRange : Parser {
		/// <summary>
		/// Whether decimal values are allowed
		/// </summary>
		public bool AllowDecimals;
		public override string Identifier => "minecraft:range";
		public override byte[] Bytes => new byte[] { (byte)(AllowDecimals ? 1 : 0) };
		public ParserRange(bool AllowDecimals) {
			this.AllowDecimals = AllowDecimals;
		}
	}
}
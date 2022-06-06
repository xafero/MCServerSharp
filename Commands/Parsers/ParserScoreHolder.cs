using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserScoreHolder : Parser {
		public bool AllowMultiple;
		public override string Identifier => "minecraft:score_holder";
		public override byte[] Bytes => new byte[] { (byte)(AllowMultiple ? 1 : 0) };
		public ParserScoreHolder(bool AllowMultiple) {
			this.AllowMultiple = AllowMultiple;
		}
	}
}
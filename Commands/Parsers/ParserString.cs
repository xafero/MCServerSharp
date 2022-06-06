using MCServerSharp.Data.Utils;
using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserString : Parser {
		public VarInt Flag;
		public enum Flags {
			/// <summary>
			/// Reads a single word
			/// </summary>
			SINGLE_WORD,
			/// <summary>
			/// If it starts with a ", keeps reading until another " (allowing escaping with \). Otherwise behaves the same as SINGLE_WORD
			/// </summary>
			QUOTABLE_PHRASE,
			/// <summary>
			/// Reads the rest of the content after the cursor. Quotes will not be removed.
			/// </summary>
			GREEDY_PHRASE
		}
		public override string Identifier => "brigadier:string";
		public override byte[] Bytes => Flag.Buffer;
		public ParserString(Flags Flag) {
			this.Flag = (int)Flag;
		}
	}
}
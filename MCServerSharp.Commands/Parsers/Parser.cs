using System;

namespace MCServerSharp.Commands.Parsers {
	/// <summary>
	/// Only for argument nodes
	/// https://wiki.vg/Command_Data#Parsers
	/// </summary>
	public abstract class Parser {
		/// <summary>
		/// Identifier of the parser
		/// </summary>
		public abstract string Identifier { get; }
		/// <summary>
		/// Bytes of properties
		/// </summary>
		public virtual byte[] Bytes => Array.Empty<byte>();

        public virtual bool Verify(string str)
        {
			// TODO Maybe fix?!
            return true;
        }
    }
}
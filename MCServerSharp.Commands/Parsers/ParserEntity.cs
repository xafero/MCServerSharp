using System;

namespace MCServerSharp.Commands.Parsers {
	public class ParserEntity : Parser {
		public byte Flag;
		public enum Flags : byte {
			NoLimit,
			SingleEntityOrPlayer,
			Players,
			SinglePlayer
		}
		public override string Identifier => "minecraft:entity";
		public override byte[] Bytes => new byte[] { Flag };
		public ParserEntity(Flags Flag) {
			this.Flag = (byte)Flag;
		}
	}
}
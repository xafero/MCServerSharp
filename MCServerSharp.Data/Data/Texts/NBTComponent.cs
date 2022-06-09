using MCServerSharp.Data.NBTs;
using System;
using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class NBTComponent : IContentComponent {
		public NBTPath NBT;
		public bool Interpret;
		public INBTTarget Target;
		public void Write(Utf8JsonWriter writer) {
			throw new NotImplementedException();
		}
	}
}

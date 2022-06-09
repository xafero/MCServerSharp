using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public interface IChatComponent {
		public void Write(Utf8JsonWriter writer);
	}
}

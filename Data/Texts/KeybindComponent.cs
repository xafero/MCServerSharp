using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class KeybindComponent : IContentComponent {
		public string Keybind;
		public KeybindComponent(string Keybind) {
			this.Keybind = Keybind;
		}
		public void Write(Utf8JsonWriter writer) {
			writer.WriteString("keybind", Keybind);
		}
	}
}

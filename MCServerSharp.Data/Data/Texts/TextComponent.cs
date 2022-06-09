using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class TextComponent : IContentComponent {
		public string Text;
		public TextComponent(string Text) {
			this.Text = Text;
		}
		public void Write(Utf8JsonWriter writer) {
			writer.WriteString("text", Text);
		}
	}
}
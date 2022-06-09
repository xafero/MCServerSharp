using System.Collections.Generic;
using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class TranslateComponent : IContentComponent {
		public string TextToTranslate;
		public List<string> Arguments;
		public void Write(Utf8JsonWriter writer) {
			writer.WriteString("translate", TextToTranslate);
			if (Arguments != null && Arguments.Count > 0) {
				writer.WriteStartArray("with");
				foreach (var s in Arguments)
					writer.WriteStringValue(s);
				writer.WriteEndArray();
			}
		}
		public string LegacyText(Dictionary<string, string> Locale) {
			if (Locale.TryGetValue(TextToTranslate, out var s))
				return s;
			return TextToTranslate;
		}
	}
}

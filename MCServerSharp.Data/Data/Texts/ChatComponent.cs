using MCServerSharp.Data.Utils;
using System;
using System.IO;
using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class ChatComponent {
		#nullable enable
		public IContentComponent Content;
		public Color? Color;
		public bool Bold;
		public bool Italic;
		public bool Underlined;
		public bool Strikethrough;
		public bool Obfuscated;
		public string? Font;
		public string? Insertion;
		public ClickEventComponent? ClickEvent;
		public HoverEventComponent? HoverEvent;
		public ChatComponent? Extra;

		public ChatComponent(IContentComponent Content) {
			this.Content = Content;
		}

		public virtual string LegacyText {
			get {
				//TODO
				return null;
			}
		}

		public virtual void Write(Utf8JsonWriter writer) {
			Content.Write(writer);
			if (Color != null)
				writer.WriteString("color", Color.Name);
			if (Bold)
				writer.WriteBoolean("bold", true);
			if (Italic)
				writer.WriteBoolean("italic", true);
			if (Underlined)
				writer.WriteBoolean("underlined", true);
			if (Strikethrough)
				writer.WriteBoolean("strikethrough", true);
			if (Obfuscated)
				writer.WriteBoolean("obfuscated", true);
			if (!string.IsNullOrEmpty(Font))
				writer.WriteString("font", Font);
			if (!string.IsNullOrEmpty(Insertion))
				writer.WriteString("insertion", Insertion);
			if (ClickEvent != null)
				ClickEvent.Write(writer);
			if (HoverEvent != null)
				HoverEvent.Write(writer);
			if (Extra != null)
				Extra.Write(writer);
		}

		public virtual Span<byte> GetBytes() {
			using var ms = new MemoryStream();
			using var writer = new Utf8JsonWriter(ms);
			Write(writer);
			writer.Flush();
			return new(ms.GetBuffer(), 0, (int)ms.Length);
		}

		public override string ToString() {
			return Util.UTF8.GetString(GetBytes());
		}
	}
}

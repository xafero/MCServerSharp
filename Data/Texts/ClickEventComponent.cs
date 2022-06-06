using System;
using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class ClickEventComponent : IChatComponent {
		public enum Actions {
			OpenUrl,
			RunCommand,
			SuggestCommand,
			ChangePage,
			CopyToClipboard
		}

		public Actions Action;
		public string Value;

		public ClickEventComponent(Actions Action, string Value) {
			if ((int)Action > 4)
				throw new ArgumentException("Unknown action: " + Action.ToString(), nameof(Action));
			this.Action = Action;
			this.Value = Value;
		}
		public void Write(Utf8JsonWriter writer) {
			writer.WriteStartObject("clickEvent");
			writer.WriteString("action", Action switch {
				Actions.OpenUrl => "open_url",
				Actions.RunCommand => "run_command",
				Actions.SuggestCommand => "suggest_command",
				Actions.ChangePage => "change_page",
				Actions.CopyToClipboard => "copy_to_clipboard",
				_ => throw new ArgumentException("Unknown action: " + Action.ToString(), nameof(Action)),
			});
			writer.WriteString("value", Value);
			writer.WriteEndObject();
		}
	}
}
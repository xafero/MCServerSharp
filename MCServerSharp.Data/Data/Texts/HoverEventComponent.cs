using MCServerSharp.Data.NBTs;
using System;
using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class HoverEventComponent : IChatComponent {
		public enum Actions {
			ShowText,
			ShowItem,
			ShowEntity
		}

		public Actions Action;
		public NBT Value;

		public HoverEventComponent(Actions Action, NBT Value) {
			if ((int)Action > 4)
				throw new ArgumentException("Unknown action: " + Action.ToString(), nameof(Action));
			this.Action = Action;
			this.Value = Value;
		}
		public void Write(Utf8JsonWriter writer) {
			writer.WriteStartObject("hoverEvent");
			writer.WriteString("action", Action switch {
				Actions.ShowText => "show_text",
				Actions.ShowItem => "show_item",
				Actions.ShowEntity => "show_entity",
				_ => throw new ArgumentException("Unknown action: " + Action.ToString(), nameof(Action)),
			});
			writer.WriteString("value", Value.ToString());
			writer.WriteEndObject();
		}
	}
}
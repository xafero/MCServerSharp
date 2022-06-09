using MCServerSharp.Data.Scores;
using System.Text.Json;

namespace MCServerSharp.Data.Texts {
	public class ScoreComponent : IContentComponent {
		public string Target;
		public Objective Objective;
		
		public ScoreComponent(string Target, Objective Objective) {
			this.Target = Target;
			this.Objective = Objective;
		}
		public void Write(Utf8JsonWriter writer) {
			writer.WriteStartObject("score");
			writer.WriteString("name", Target);
			writer.WriteString("objective", Objective.Name);
			writer.WriteEndObject();
		}
	}
}
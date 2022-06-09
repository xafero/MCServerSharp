namespace MCServerSharp.Data.Entities {
	public class ConsoleExcutor : ICommandExecutor {
		public static ConsoleExcutor Instance = new();
		protected ConsoleExcutor() {
		}
		public virtual bool IsOp => true;
		public virtual string DisplayName => "§cConsole";

		public virtual bool HasPermission(string permission) => true;

		public virtual void SendMessage(string message) => Server.Log(message);
	}
}

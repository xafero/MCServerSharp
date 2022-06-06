namespace MCServerSharp.Data.Entities {
	public interface ICommandExecutor {
		/// <summary>
		/// Whether the excutor is operator of server
		/// </summary>
		public bool IsOp { get; }
		/// <summary>
		/// Displayed Name of the excutor
		/// </summary>
		public string DisplayName { get; }
		/// <summary>
		/// Check if the excutor has the permission
		/// </summary>
		public bool HasPermission(string permission);
		/// <summary>
		/// Send message to the excutor has the permission
		/// </summary>
		public void SendMessage(string message);
	}
}

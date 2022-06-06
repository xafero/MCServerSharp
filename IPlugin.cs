namespace MCServerSharp {
	public interface IPlugin {
		public string Name { get; }
		public void OnEnable();
		public void OnDisable();
	}
}
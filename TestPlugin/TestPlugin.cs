using MCServerSharp;
using System;

namespace TestPlugin {
	public class TestPlugin : IPlugin {
		public string Name => "TestPluginName";
		public void OnEnable() {
			Console.WriteLine("TestPlugin Enabled");
		}
		public void OnDisable() {
			Console.WriteLine("TestPlugin Disabled");
		}
	}
}
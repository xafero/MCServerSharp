using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Loader;

namespace MCServerSharp {
	public static class PluginManager {
		public static AssemblyLoadContext PluginLoader;
		public static readonly Dictionary<string, IPlugin> Plugins = new();

		/// <summary>
		/// Unload all plugins and load all plugins in <paramref name="path"/>
		/// </summary>
		/// <param name="path"></param>
		public static void ReloadPlugins(string path) {
			UnLoadAllPlugins();
			Server.Log("Loading plugins");
			Directory.CreateDirectory(path);
			PluginLoader = new AssemblyLoadContext("Plugins", true);
			foreach (var f in Directory.GetFiles(path, "*.dll"))
				using (var fs = File.OpenRead(f))
					Server.Log("Loaded assembly: " + PluginLoader.LoadFromStream(fs).FullName);
			foreach (var a in PluginLoader.Assemblies)
				foreach (var t in a.GetExportedTypes())
					if (t.IsAssignableTo(typeof(IPlugin)) && !t.IsAbstract && !t.IsInterface) {
						var p = Activator.CreateInstance(t) as IPlugin;
						if (Plugins.TryAdd(p.Name, p)) {
							p.OnEnable();
							Server.Log("Enabled plugin: " + p.Name);
						} else {
							Server.LogError($"A plugin has the same name with the other one: {p.Name}\r\nIn assembly: {a.FullName}");
							if (p is IDisposable d) d.Dispose();
						}
					}
		}

		/// <summary>
		/// Load a assembly and its plugins
		/// </summary>
		/// <param name="DllPath"></param>
		public static void LoadPlugin(string DllPath) {
			PluginLoader ??= new AssemblyLoadContext("Plugins", true);
			using var fs = File.OpenRead(DllPath);
			var a = PluginLoader.LoadFromStream(fs);
			Server.Log("Loaded assembly: " + a.FullName);
			foreach (var t in a.GetExportedTypes())
				if (t.IsAssignableTo(typeof(IPlugin)) && !t.IsAbstract && !t.IsInterface) {
					var p = Activator.CreateInstance(t) as IPlugin;
					if (Plugins.TryAdd(p.Name, p)) {
						p.OnEnable();
						Server.Log("Enabled plugin: " + p.Name);
					} else {
						Server.LogError($"A plugin has the same name with the other one: {p.Name}\r\nIn assembly: {a.FullName}");
						if (p is IDisposable d) d.Dispose();
					}
				}
		}

		/// <summary>
		/// Unload all plugins
		/// </summary>
		public static void UnLoadAllPlugins() {
			if (PluginLoader != null || Plugins.Count > 0) Server.Log("Unloading all plugins");
			foreach (var p in Plugins.Values)
				try {
					p.OnDisable();
					Server.Log("Disabled plugin: " + p.Name);
				} catch (Exception ex) {
					Server.LogError(new PluginException("An error occurred while disabling a plugin", ex, p).ToString());
				}
			Plugins.Clear();
			if (PluginLoader != null)
				PluginLoader.Unload();
			PluginLoader = null;
		}
	}

	/// <summary>
	/// Exception caused by plugins
	/// </summary>
	public class PluginException : Exception {
		/// <summary>
		/// Plugins which caused this exception
		/// </summary>
		public IPlugin Plugin { get; }
		public PluginException(string message, IPlugin plugin = null) : base(message + plugin == null ? "" : "\r\nPlugin: " + plugin.Name) {
			Plugin = plugin;
		}
		public PluginException(string message, Exception innerException, IPlugin plugin = null) : base(message + plugin == null ? "" : "\r\nPlugin: " + plugin.Name, innerException) {
			Plugin = plugin;
		}
		public PluginException(string message, string pluginName) : base(message + "\r\nPlugin: " + pluginName) { }
		public PluginException(string message, Exception innerException, string pluginName) : base(message + "\r\nPlugin: " + pluginName, innerException) { }
	}
}
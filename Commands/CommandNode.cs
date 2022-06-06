using MCServerSharp.Data.Entities;
using MCServerSharp.Data.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace MCServerSharp.Commands {
	/*
	The graph consists of nodes of type "root", "literal" and "rgument".
	A node may point to a number child nodes, or redirect to another node, or neither.
	The root node is nameless, and its children are literal nodes for familiar commands ("msg", "me", etc).

	Nodes are marked as executable if the node stack to this point constitutes a valid command.
	E.g. this is false for "/ban" but true for "/ban Dinnerbone" and "/ban Dinnerbone created this crazy format".

	When including redirects, this classure is a directed graph that may include cycles (e.g. consider "/execute run execute run execute ...").
	When excluding redirects, the classure no longer contains cycles but may still not be a tree, as a node may have multiple parents.

	Source: wiki.vg
	*/

	/// <summary>
	/// https://wiki.vg/Command_Data
	/// </summary>
	public abstract class CommandNode {
		public enum Suggestions {
			AskServer,
			AllRecipes,
			AvailableSounds,
			SummonableEntities
		}
		/// <summary>
		/// True if the node stack to this point constitutes a valid command
		/// </summary>
		public bool IsExecutable;
		/// <summary>
		/// List of child nodes
		/// </summary>
		public readonly List<CommandNode> ChildNodes = new();
		/// <summary>
		/// Name of this node
		/// </summary>
		public string Name;
		/// <summary>
		/// Node of this node redirect to, null if no redirect
		/// </summary>
		#nullable enable
		public CommandNode? RedirectNode;
		/// <summary>
		/// Type of suggestions of this node, null if no suggestions
		/// </summary>
		public Suggestions? SuggestionsType;

		internal VarInt index;

		protected CommandNode(string Name, bool IsExecutable, CommandNode? RedirectNode, Suggestions? SuggestionsType) {
			this.Name = Name;
			this.IsExecutable = IsExecutable;
			this.RedirectNode = RedirectNode;
			this.SuggestionsType = SuggestionsType;
		}

		internal abstract Span<byte> GetBytes();

		static CommandNode() {
			RegisterCommand(new LiteralNode("stop", true) { 
				OnExecute = (sender, _, _) => {
					if (sender.HasPermission("admin.stop"))
						Server.Instance.Close();
					else
						sender.SendMessage("§cYou don't have permission to do this.");
				}
			});
			//TODO
		}

		public static bool RunCommand(ICommandExecutor sender, string command) {
			try {
				var i = command.IndexOf(' ');
				string next;
				if (i > 0)
					next = command[..i];
				else
					next = command;
				return Commands.First(n => n is LiteralNode && n.Name == next).RunCommand(sender, command, i + 1);
			} catch (Exception ex) {
				Server.LogError(ex.ToString());
				sender.SendMessage("§cAn error occurred while executing the command");
				return true;
			}
		}

		protected internal virtual bool RunCommand(ICommandExecutor Executor, string CommandLine, int index, ICommandExecutor? Sender = null) {
			if (index <= 0) {
				if (!IsExecutable) return false;
				OnExecute(Executor, CommandLine, Sender);
				return true;
			}
			var i = CommandLine.IndexOf(' ');
			string next;
			if (i > 0)
				next = CommandLine[index..i];
			else
				next = CommandLine[index..];
			return ChildNodes.First(n => n is LiteralNode && n.Name == next || n is ArgumentNode a && a.Parser.Verify(next)).RunCommand(Executor, CommandLine, i + 1);
		}

		/// <summary>
		/// Called when execute the command, ignored if isn't executable.
		/// </summary>
		public ExecuteHandler? OnExecute;

		/// <param name="CommandLine">The whole executed command line (doesn't contain '/')</param>
		/// <param name="Sender">Who sent this command</param>
		/// <param name="Executor">Executor of this command, only if the command was executed by /execute as ...</param>
		public delegate void ExecuteHandler(ICommandExecutor Executor, string CommandLine,  ICommandExecutor? Sender);

		internal static readonly byte[] Suggestions_AskServer = "minecraft:ask_server".AsSpan().GetBytes();
		internal static readonly byte[] Suggestions_AllRecipes = "minecraft:all_recipes".AsSpan().GetBytes();
		internal static readonly byte[] Suggestions_AvailableSounds = "minecraft:available_sounds".AsSpan().GetBytes();
		internal static readonly byte[] Suggestions_SummonableEntities = "minecraft:summonable_entities".AsSpan().GetBytes();

		private static readonly List<CommandNode> commandnodes = new();
		private static readonly List<CommandNode> commands = new();
		/// <summary>
		/// All CommandNodes
		/// </summary>
		public static ReadOnlyCollection<CommandNode> CommandNodes => commandnodes.AsReadOnly();
		/// <summary>
		/// All Registered commands
		/// </summary>
		public static ReadOnlyCollection<CommandNode> Commands => commands.AsReadOnly();
		internal static byte[]? DeclareCommandsBytes;
		internal static void BuildCommands() {
			for (var i = 1; i <= commandnodes.Count; ++i)
				commandnodes[i].index = i;
			var ms = new MemoryStream();
			ms.Write(new VarInt(commandnodes.Count + 1).Buffer);

			// RootNode
			ms.WriteByte(0);
			ms.Write(new VarInt(commands.Count).Buffer);
			foreach (var n in commands)
				ms.Write(n.index.Buffer);

			foreach (var c in commandnodes)
				ms.Write(c.GetBytes());

			ms.WriteByte(0);
			DeclareCommandsBytes = ms.ToArray();
			ms.Close();
		}
		/// <summary>
		/// Register a LiteralNode as a command and add it to server
		/// </summary>
		public static void RegisterCommand(LiteralNode node) {
			if (DeclareCommandsBytes != null)
				throw new InvalidOperationException("Commands can only be changed in OnEnable() of plugins");
			if (!commands.Contains(node))
				commands.Add(node);
			if (!commandnodes.Contains(node))
				commandnodes.Add(node);
		}
		/// <summary>
		/// Add a CommandNode to server
		/// </summary>
		public static void AddNode(CommandNode node) {
			if (DeclareCommandsBytes != null)
				throw new InvalidOperationException("Commands can only be changed in OnEnable() of plugins");
			if (!commandnodes.Contains(node))
				commandnodes.Add(node);
		}
		/// <summary>
		/// Unregister a command
		/// </summary>
		public static void UnregisterCommand(LiteralNode node) {
			if (DeclareCommandsBytes != null)
				throw new InvalidOperationException("Commands can only be changed in OnEnable() of plugins");
			commands.Remove(node);
		}
		/// <summary>
		/// Remove a CommandNode from server, If it is a command it will also be unregistered. You must remove all node that direct to this node too.
		/// </summary>
		public static void RemoveNode(CommandNode node) {
			if (DeclareCommandsBytes != null)
				throw new InvalidOperationException("Commands can only be changed in OnEnable() of plugins");
			commandnodes.Remove(node);
			commands.Remove(node);
		}
	}
}
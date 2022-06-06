using MCServerSharp.Data.Utils;
using System;
using System.IO;

namespace MCServerSharp.Commands {
	public class LiteralNode : CommandNode {
		#nullable enable
		public LiteralNode(string Name, bool IsExecutable, CommandNode? RedirectNode = null, Suggestions? SuggestionsType = null) : base(Name, IsExecutable, RedirectNode, SuggestionsType) {
		}

		internal override Span<byte> GetBytes() {
			if (string.IsNullOrEmpty(Name))
				throw new ArgumentNullException(nameof(Name), "Name of ArgumentNode and LiteralNode must be define");
			using var ms = new MemoryStream();
			var flag = 1;
			if (IsExecutable) {
				if (OnExecute == null)
					throw new NullReferenceException("OnExecute of the executable LiteralNode:\"" + Name + "\" is null");
				flag |= 4;
			}
			if (RedirectNode != null) flag |= 8;
			if (SuggestionsType.HasValue) flag |= 16;
			ms.WriteByte((byte)flag);
			ms.Write(new VarInt(ChildNodes.Count).Buffer);
			foreach (var i in ChildNodes)
				ms.Write(new VarInt(i.index).Buffer);
			if (RedirectNode != null)
				ms.Write(new VarInt(RedirectNode.index).Buffer);
			ms.Write(Name.AsSpan().GetBytes());
			if (SuggestionsType.HasValue)
				ms.Write(SuggestionsType.Value switch {
					Suggestions.AskServer => Suggestions_AskServer,
					Suggestions.AllRecipes => Suggestions_AllRecipes,
					Suggestions.AvailableSounds => Suggestions_AvailableSounds,
					Suggestions.SummonableEntities => Suggestions_SummonableEntities,
					_ => throw new ArgumentException("Unknown type", nameof(SuggestionsType)),
				});
			return new Span<byte>(ms.GetBuffer(), 0, (int)ms.Length);
		}
	}
}

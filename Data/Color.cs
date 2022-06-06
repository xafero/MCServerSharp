using System;

namespace MCServerSharp.Data {
	public class Color {
		public string Name;
		public string Code;
		public ConsoleColor Value;
		protected Color(string name, string code, ConsoleColor value) {
			Name = name;
			Code = code;
			Value = value;
		}
		public static implicit operator ConsoleColor(Color v) => v.Value;
		public static explicit operator Color(ConsoleColor v) => v switch {
			ConsoleColor.Black => Black,
			ConsoleColor.DarkBlue => Dark_Blue,
			ConsoleColor.DarkGreen => Dark_Green,
			ConsoleColor.DarkCyan => Dark_Aqua,
			ConsoleColor.DarkRed => Dark_Red,
			ConsoleColor.DarkMagenta => Dark_Purple,
			ConsoleColor.DarkYellow => Gold,
			ConsoleColor.Gray => Gray,
			ConsoleColor.DarkGray => Dark_Gray,
			ConsoleColor.Blue => Blue,
			ConsoleColor.Green => Green,
			ConsoleColor.Cyan => Aqua,
			ConsoleColor.Red => Red,
			ConsoleColor.Magenta => Light_Purple,
			ConsoleColor.Yellow => Yellow,
			ConsoleColor.White => White,
			_ => throw new InvalidCastException("Unable to convert " + v.ToString() + " to Color")
		};

		public static Color Black = new("Black", "§0", ConsoleColor.Black);
		public static Color Dark_Blue = new("Dark_Blue", "§1", ConsoleColor.DarkBlue);
		public static Color Dark_Green = new("Dark_Green", "§2", ConsoleColor.DarkGreen);
		public static Color Dark_Aqua = new("Dark_Aqua", "§3", ConsoleColor.DarkCyan);
		public static Color Dark_Red = new("Dark_Red", "§4", ConsoleColor.DarkRed);
		public static Color Dark_Purple = new("Dark_Purple", "§5", ConsoleColor.DarkMagenta);
		public static Color Gold = new("Gold", "§6", ConsoleColor.DarkYellow);
		public static Color Gray = new("Gray", "§7", ConsoleColor.Gray);
		public static Color Dark_Gray = new("DarkGray", "§8", ConsoleColor.DarkGray);
		public static Color Blue = new("Blue", "§9", ConsoleColor.Blue);
		public static Color Green = new("Green", "§a", ConsoleColor.Green);
		public static Color Aqua = new("Aqua", "§b", ConsoleColor.Cyan);
		public static Color Red = new("Red", "§c", ConsoleColor.Red);
		public static Color Light_Purple = new("Light_Purple", "§d", ConsoleColor.Magenta);
		public static Color Yellow = new("Yellow", "§e", ConsoleColor.Yellow);
		public static Color White = new("White", "§f", ConsoleColor.White);
		public static readonly string Obfuscated = "§k";
		public static readonly string Bold = "§l";
		public static readonly string Strikethrough = "§m";
		public static readonly string Underline = "§n";
		public static readonly string Italic = "§o";
		public static readonly string Reset = "§r";
	}
}

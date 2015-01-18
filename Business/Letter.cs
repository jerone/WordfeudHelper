using System;
using HelperFramework.DataType;

namespace WordfeudHelper.Business
{
	class Letter : StaticList<Letter>
	{
		public String Charackter { get; private set; }
		public Int32 Count { get; private set; }
		public Int32 Points { get; private set; }

		public Letter(String charakter, Int32 points, Int32 count)
		{
			Charackter = charakter.ToUpper();
			Count = count;
			Points = points;
		}

		public Letter(String charakter, Int32 points)
			: this(charakter, points, 1) { }

		public Letter(String charakter)
			: this(charakter, 1, 1) { }

		public Letter() { }

		public class Dutch : StaticList<Letter>
		{
			public static Letter A = new Letter("a", 1, 7);
			public static Letter B = new Letter("b", 4, 2);
			public static Letter C = new Letter("c", 5, 2);
			public static Letter D = new Letter("d", 2, 5);
			public static Letter E = new Letter("e", 1, 18);
			public static Letter F = new Letter("f", 4, 2);
			public static Letter G = new Letter("g", 3, 3);
			public static Letter H = new Letter("h", 4, 2);
			public static Letter I = new Letter("i", 2, 4);
			public static Letter J = new Letter("j", 4, 2);
			public static Letter K = new Letter("k", 3, 3);
			public static Letter L = new Letter("l", 3, 3);
			public static Letter M = new Letter("m", 3, 3);
			public static Letter N = new Letter("n", 1, 11);
			public static Letter O = new Letter("o", 1, 6);
			public static Letter P = new Letter("p", 4, 2);
			public static Letter Q = new Letter("q", 10, 1);
			public static Letter R = new Letter("r", 2, 5);
			public static Letter S = new Letter("s", 2, 5);
			public static Letter T = new Letter("t", 2, 5);
			public static Letter U = new Letter("u", 2, 3);
			public static Letter V = new Letter("v", 4, 2);
			public static Letter W = new Letter("w", 5, 2);
			public static Letter X = new Letter("x", 8, 1);
			public static Letter Y = new Letter("y", 8, 1);
			public static Letter Z = new Letter("z", 5, 2);
		}
	}
}
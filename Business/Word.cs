using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WordfeudHelper.Business
{
	public class Word
	{

		public String Value { get; set; }

		public Int32 Points { get { return CalculateWordPoints(Value); } }

		public Int32 Length { get { return Value.Length; } }

		public Dictionary<Int32, Char> Matches = new Dictionary<Int32, Char>();

		public Word(String value)
		{
			Value = value;
		}

		private static Int32 CalculateWordPoints(String word)
		{
			return word.ToUpper().Sum(__letter => Letter.Get(__letter.ToString(CultureInfo.InvariantCulture), typeof(Letter.Dutch)).Points);
		}
	}
}

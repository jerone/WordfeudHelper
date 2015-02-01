using HelperFramework.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordfeudHelper.Business
{
	/// <summary>
	/// Search Type
	/// </summary>
	public class SearchType : StaticList<SearchType>
	{
		public String Name { get; set; }
		public Boolean UseLetters { get; set; }
		public Boolean UseExtra { get; set; }
		public Func<String, String, List<Word>, List<Word>> MatchList { get; set; }
		public Func<String, String, Word, Boolean> MatchItem { get; set; }

		#region Private Methods;

		private const String BLANK_TILE_MATCH = "blanktilematch";

		/// <summary>
		/// Checks if match contains asterisk for blank tile
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		private static Boolean ContainsBlankTileAsterisk(String match)
		{
			return Regex.IsMatch(match, @"\*");
		}

		/// <summary>
		/// Convert asterisk to regex for blank tile
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		private static String ConvertBlankTileAsterisk(String match)
		{
			return String.Format("(?<{0}>{1})", BLANK_TILE_MATCH, Regex.Escape(match).Replace(@"\*", @"."));
		}

		private static Boolean IsMatch(String type, String letters, String extra, Word word)
		{
			// Suggested words should never be smaller then extra value, 
			//  and not equal or smaller when letters are being used;
			if (word.Value.Length < extra.Length || (letters.Length > 0 && word.Value.Length <= extra.Length))
			{
				return false;
			}

			Boolean success = true;
			Int32 startIndex = 0;

			if (ContainsBlankTileAsterisk(extra))
			{
				String regex;
				switch (type)
				{
					case "<":  // Starts with;
						{
							regex = String.Format("^{0}.*", ConvertBlankTileAsterisk(extra));
							break;
						}
					case ">":  // Ends with;
						{
							regex = String.Format(".*{0}$", ConvertBlankTileAsterisk(extra));
							break;
						}
					case "<>":  // Contains;
					default:
						{
							regex = String.Format(".*{0}.*", ConvertBlankTileAsterisk(extra));
							break;
						}
					case "=":  // Equals;
						{
							regex = String.Format("^{0}$", ConvertBlankTileAsterisk(extra));
							break;
						}
				}
				Match match = Regex.Match(word.Value, regex, RegexOptions.IgnoreCase);
				success = match.Success;
				if (success && letters.Length > 0)
				{
					Group group = match.Groups[BLANK_TILE_MATCH];
					extra = group.Value;
					startIndex = group.Index;
				}
			}
			else
			{
				switch (type)
				{
					case "<":  // Starts with;
						{
							success = word.Value.StartsWith(extra);
							break;
						}
					case ">":  // Ends with;
						{
							success = word.Value.EndsWith(extra);
							break;
						}
					case "<>":  // Contains;
					default:
						{
							success = word.Value.Contains(extra);
							break;
						}
					case "=":  // Equals;
						{
							success = word.Value.Equals(extra);
							break;
						}
				}
				startIndex = 0;
			}

			if (success && letters.Length > 0)
			{
				//for (Int32 i = startIndex; i < __extra.Length + startIndex; i++)
				//{
				//	__word.Matches.Add(i, __word.Value[i]);
				//}
				success = Suggest.MatchItem(letters + extra, null, word);
			}

			return success;
		}

		#endregion Private Methods;

		#region public static SearchType StartsWith;

		/// <summary>
		/// Starts With
		/// </summary>
		public static SearchType StartsWith = new SearchType
		{
			Name = "Begint met",
			UseLetters = true,
			UseExtra = true,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => StartsWith.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) =>
				{
					// Extra value should always contain a value;
					if (__extra.Length == 0)
					{
						return false;
					}

					return IsMatch("<", __letters, __extra, __word);
				}
		};

		#endregion public static SearchType StartsWith;

		#region public static SearchType EndsWith;

		/// <summary>
		/// Ends With
		/// </summary>
		public static SearchType EndsWith = new SearchType
		{
			Name = "Eindigd met",
			UseLetters = true,
			UseExtra = true,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => EndsWith.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) =>
				{
					// Extra value should always contain a value;
					if (__extra.Length == 0)
					{
						return false;
					}

					return IsMatch(">", __letters, __extra, __word);
				}
		};

		#endregion public static SearchType EndsWith;

		#region public static SearchType Contains;

		/// <summary>
		/// Contains
		/// </summary>
		public static SearchType Contains = new SearchType
		{
			Name = "Bevat",
			UseLetters = true,
			UseExtra = true,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => Contains.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) => IsMatch("<>", __letters, __extra, __word)
		};

		#endregion public static SearchType Contains;

		#region public static SearchType Equals;

		/// <summary>
		/// Equals
		/// </summary>
		public static new SearchType @Equals = new SearchType
		{
			Name = "Gelijk",
			UseLetters = false,
			UseExtra = true,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => @Equals.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) =>
				{
					return IsMatch("=", __letters, __extra, __word);
				}
		};

		#endregion public static SearchType Equals;

		#region public static SearchType Regexp;

		/// <summary>
		/// Regex
		/// </summary>
		public static SearchType Regexp = new SearchType
		{
			Name = "Regex",
			UseLetters = false,
			UseExtra = true,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => Regexp.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) => Regex.IsMatch(__word.Value, __letters, RegexOptions.IgnoreCase)
		};

		#endregion public static SearchType Regexp;

		#region public static SearchType Suggest;

		/// <summary>
		/// Regex
		/// </summary>
		public static SearchType Suggest = new SearchType
		{
			Name = "Suggestie",
			UseLetters = true,
			UseExtra = false,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => __word.Value.Length <= __letters.Length)  // Same length or longer only;
						  .Where(__word => Suggest.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) =>
				{
					String searchLetters = __letters;
					foreach (Char wordLetter in __word.Value)
					{
						Char letter = wordLetter;
						if (!searchLetters.Contains(letter))
						{
							// Need to check everytime, because there could be more then one `*`;
							if (searchLetters.Contains("*"))
							{
								letter = '*';
							}
							else
							{
								return false;
							}
						}

						// Remove this letter from search letters, 
						//  so it's only matched once when it contains one of this letter.
						//  e.g.: search 'pa' shouldn't match 'aap'.
						searchLetters = searchLetters.Remove(searchLetters.IndexOf(letter), 1);
					}
					return true;
				}
		};

		#endregion public static SearchType Suggest;

	}
}

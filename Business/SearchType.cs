using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HelperFramework.DataType;

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
					Boolean success;
					Int32 startIndex = 0;

					if (ContainsBlankTileAsterisk(__extra))
					{
						Match match = Regex.Match(__word.Value,
										String.Format("^{0}.*", ConvertBlankTileAsterisk(__extra)),
										RegexOptions.IgnoreCase);
						success = match.Success;
						if (success && __letters.Length > 0)
						{
							Group group = match.Groups[BLANK_TILE_MATCH];
							__extra = group.Value;
							startIndex = group.Index;
						}
					}
					else
					{
						success = __word.Value.StartsWith(__extra);
						startIndex = 0;
					}

					if (success && __letters.Length > 0)
					{
						for (Int32 i = startIndex; i < __extra.Length + startIndex; i++)
						{
							__word.Matches.Add(i, __word.Value[i]);
						}
						//String word = __word.Value;
						//__word.Value = __word.Value.Substring(__extra.Length);
						success = Suggest.MatchItem(__letters, __extra, __word);
						//__word.Value = word;
					}

					return success;
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
					Boolean success;

					if (ContainsBlankTileAsterisk(__extra))
					{
						Match match = Regex.Match(__word.Value, String.Format(".*{0}$", ConvertBlankTileAsterisk(__extra)),
										RegexOptions.IgnoreCase);
						success = match.Success;
						if (success && __letters.Length > 0)
						{
							__extra = match.Groups[BLANK_TILE_MATCH].Value;
						}
					}
					else
					{
						success = __word.Value.EndsWith(__extra);
					}

					if (success && __letters.Length > 0)
					{
						String word = __word.Value.Remove(__extra);
						success = Suggest.MatchItem(__letters, String.Empty, new Word(word));
					}

					return success;
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
				(__letters, __extra, __word) =>
				{
					Boolean success;

					if (ContainsBlankTileAsterisk(__extra))
					{
						Match match = Regex.Match(__word.Value, String.Format(".*{0}.*", ConvertBlankTileAsterisk(__extra)),
										RegexOptions.IgnoreCase);
						success = match.Success;
						if (success && __letters.Length > 0)
						{
							__extra = match.Groups[BLANK_TILE_MATCH].Value;
						}
					}
					else
					{
						success = __word.Value.Contains(__extra);
					}

					if (success && __letters.Length > 0)
					{
						String word = __word.Value.Remove(__extra);
						success = Suggest.MatchItem(__letters, String.Empty, new Word(word));
					}

					return success;
				}
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
					Boolean success;

					if (ContainsBlankTileAsterisk(__extra))
					{
						Match match = Regex.Match(__word.Value, String.Format("^{0}$", ConvertBlankTileAsterisk(__extra)),
										RegexOptions.IgnoreCase);
						success = match.Success;
						if (success && __letters.Length > 0)
						{
							__extra = match.Groups[BLANK_TILE_MATCH].Value;
						}
					}
					else
					{
						success = __word.Value.Equals(__extra);
					}

					if (success && __letters.Length > 0)
					{
						String word = __word.Value.Remove(__extra);
						success = Suggest.MatchItem(__letters, String.Empty, new Word(word));
					}

					return success;
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
			UseExtra = true,
			MatchList =
				(__letters, __extra, __list) =>
					__list.Where(__word => __word.Value.Length <= __letters.Length)  // Same length only;
						  .Where(__word => Suggest.MatchItem(__letters, __extra, __word)).ToList(),
			MatchItem =
				(__letters, __extra, __word) =>  // __extra in this case will be removed from the word's value;
				{
					String search = __letters;
					foreach (Char wordLetter in __word.Value)
					{
						Char letter = wordLetter;
						if (!search.Contains(letter))
						{
							if (search.Contains("*"))
							{
								letter = '*';
							}
							else
							{
								return false;
							}
						}

						// Remove this letter from search letters, 
						// so it's only matched once when it contains one of this letter.
						// e.g.: search 'pa' shouldn't match 'aap'.
						search = search.Remove(search.IndexOf(letter), 1);
					}
					return true;
				}
		};

		#endregion public static SearchType Suggest;

	}
}

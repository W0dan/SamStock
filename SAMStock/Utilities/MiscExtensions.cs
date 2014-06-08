using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Text;
using Castle.Core.Internal;

namespace SAMStock.Utilities
{
	public static class MiscExtensions
	{
		public static bool IsMeaningful(this string s)
		{
			return !string.IsNullOrWhiteSpace(s);
		}

		public static void IfMeaningful(this string s, Action<string> succeed = null, Action fail = null)
		{
			if (s.IsMeaningful())
			{
				if (succeed != null)
				{
					succeed(s);
				}
			}
			else
			{
				if (fail != null)
				{
					fail();
				}
			}
		}

		public static void IfNotNull<T>(this T? nullable, Action<T> succeed = null, Action fail = null) where T : struct
		{
			if (nullable.HasValue)
			{
				if (succeed != null)
				{
					succeed(nullable.Value);
				}
			}
			else
			{
				if (fail != null)
				{
					fail();
				}
			}
		}

		public static string NullOrSelf(this string s, string compareto)
		{
			return s.Equals(compareto) ? null : s;
		}

		public static int? NullOrSelf(this int number, int compareto)
		{
			return number.Equals(compareto) ? (int?)null : number;
		}

		public static DateTime? NullOrSelf(this DateTime date, DateTime compareto)
		{
			return date.Equals(compareto) ? (DateTime?) null : date;
		}

		public static bool? NullOrSelf(this bool b, bool compareto)
		{
			return b == compareto ? (bool?) null : b;
		}

		public static Stream NullOrSelf(this Stream s, Stream compareto)
		{
			return s.Equals(compareto) ? null : s;
		}

		public static int Truncate<T>(this DbSet<T> set) where T : class
		{
			var count = set.Count();
			set.ForEach(x => set.Remove(x));
			return count;
		}

		public static string JoinToString<T>(this IEnumerable<T> list, string glue)
		{
			return string.Join(glue, list.Select(s => s.ToString()));
		}
	}
}
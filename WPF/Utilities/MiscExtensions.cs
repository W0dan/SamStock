using System.Windows.Controls;
using SAMStock.wpf.Exceptions;

namespace SAMStock.wpf.Utilities
{
	public static class MiscExtensions
	{
		public static decimal GetDecimal(this TextBox box)
		{
			decimal dec;
			if (decimal.TryParse(box.Text, out dec))
			{
				return dec;
			}
			else
			{
				throw new NumberFormatException(box.Text, typeof(decimal));
			}
		}

		public static int GetInt(this TextBox box)
		{
			int val;
			if (int.TryParse(box.Text, out val))
			{
				return val;
			}
			else
			{
				throw new NumberFormatException(box.Text, typeof(int));
			}
		}

		public static string GetStringWithExactLength(this TextBox box, int l)
		{
			if (box.Text.Length == l)
			{
				return box.Text;
			}
			else
			{
				throw new IllegalInputException();
			}
		}
	}
}

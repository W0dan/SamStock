using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SAMStock.wpf.Utilities
{
	public static class TextBoxExtensions
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
				throw new NumberFormatException();
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
				throw new NumberFormatException();
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

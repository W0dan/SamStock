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
		public static bool TryGetDecimal(this TextBox box, out Decimal dec)
		{
			return Decimal.TryParse(box.Text, out dec);
		}
	}
}

using System;

namespace SAMStock.wpf.Exceptions
{
	public class NumberFormatException : Exception
	{
		public NumberFormatException(string number, Type type) : base(String.Format("{0} could not be parsed as a {1}", number, type.Name))
		{
		}
	}
}

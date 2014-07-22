using System;
using WPF.Utilities;

namespace WPF.Exceptions
{
	public class NumberFormatException : ArgumentException
	{
		public NumberFormatException(string number, Type type) : base(String.Format("{0} could not be parsed as a{2} {1}", number, type.Name, type.Name.ToCharArray()[0].IsVowel()? "n": ""))
		{
		}
	}
}

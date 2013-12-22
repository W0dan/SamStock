using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Stock.ModifyStock
{
	public class ComponentInUseException : Exception
	{
		public List<string> PedalNames { get; set; }
	}
}

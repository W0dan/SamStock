using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.UpdateStock
{
	public class ComponentInUseException : Exception
	{
		public List<string> PedalNames { get; set; }
	}
}

using System;
using System.Collections.Generic;

namespace SAMStock.DAL.Component.DeleteComponent.Exceptions
{
	public class ComponentInUseException : Exception
	{
		public List<string> PedalNames { get; private set; }
 
		public ComponentInUseException(List<string> pedals)
		{
			PedalNames = pedals;
		}
	}
}

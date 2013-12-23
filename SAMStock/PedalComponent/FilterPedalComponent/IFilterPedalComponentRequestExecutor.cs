using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.FilterPedalComponent
{
	public interface IFilterPedalComponentRequestExecutor
	{
		FilterPedalComponentResponse Execute(FilterPedalComponentRequest request);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.PedalComponent.FilterPedalComponent
{
	public interface IFilterPedalComponentRequestHandler: IQueryHandler<FilterPedalComponentRequest, FilterPedalComponentResponse>
	{
		new FilterPedalComponentResponse Handle(FilterPedalComponentRequest request);
	}
}

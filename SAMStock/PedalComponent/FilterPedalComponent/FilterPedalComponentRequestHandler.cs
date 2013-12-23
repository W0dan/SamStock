using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.PedalComponent.FilterPedalComponent
{
	public class FilterPedalComponentRequestHandler: IFilterPedalComponentRequestHandler
	{
		private readonly IFilterPedalComponentRequestExecutor _executor;

		public FilterPedalComponentRequestHandler(IFilterPedalComponentRequestExecutor executor)
		{
			_executor = executor;
		}

		public FilterPedalComponentResponse Handle(FilterPedalComponentRequest request)
		{
			return _executor.Execute(request);
		}
	}
}

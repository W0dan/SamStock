using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Pedal.FilterPedal
{
	public class FilterPedalHandler : IFilterPedalHandler
	{
		private IFilterPedalQueryExecutor _queryexecutor;

		public FilterPedalHandler(IFilterPedalQueryExecutor queryexecutor)
		{
			_queryexecutor = queryexecutor;
		}

		public FilterPedalResponse Handle(FilterPedalRequest request)
		{
			return _queryexecutor.Execute(request);
		}
	}
}

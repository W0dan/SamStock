using System.Collections.Generic;
using System.Linq;
using SAMStock.DTO.Admin.GetAdminData;

namespace SAMStock.DTO.Pedal.FilterPedal
{
	public class FilterPedalHandler : IFilterPedalHandler
	{
		private readonly IFilterPedalQueryExecutor _queryexecutor;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.FilterPedal
{
	public interface IFilterPedalQueryExecutor : IQuery
	{
		FilterPedalResponse Execute(FilterPedalRequest request);
	}
}

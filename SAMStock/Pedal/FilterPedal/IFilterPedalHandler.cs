﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.FilterPedal
{
	public interface IFilterPedalHandler : IQueryHandler<FilterPedalRequest, FilterPedalResponse>
	{
		new FilterPedalResponse Handle(FilterPedalRequest request);
	}
}
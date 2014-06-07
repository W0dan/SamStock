using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsHandler: RequestHandler<FilterComponentsRequest, FilterComponentsResponse>
	{
		public FilterComponentsHandler(IRequestExecutor<FilterComponentsRequest, FilterComponentsResponse> executor) : base(executor)
		{
		}
	}
}

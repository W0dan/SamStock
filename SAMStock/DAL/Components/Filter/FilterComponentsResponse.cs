using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsResponse: IResponse
	{
		public List<BO.Component> Components { get; private set; }

		public FilterComponentsResponse(IEnumerable<BO.Component> components)
		{
			Components = components.ToList();
		}
	}
}

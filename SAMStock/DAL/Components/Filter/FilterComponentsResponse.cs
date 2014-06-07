using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsResponse: IResponse
	{
		public List<BO.Component> Components { get; private set; }

		public FilterComponentsResponse(IEnumerable<Database.Component> components)
		{
			Components = components.Select(x => new BO.Component(x)).ToList();
		}
	}
}

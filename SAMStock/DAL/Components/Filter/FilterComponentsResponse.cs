using System.Collections.Generic;
using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsResponse: IFilterResponse<Component>
	{
		public IEnumerable<Component> Items { get; private set; }

		public FilterComponentsResponse(IEnumerable<Database.Component> components)
		{
			Items = components.Select(x => new Component(x));
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsResponse: Response
	{
		public IEnumerable<Component> Items { get; private set; }

		public FilterComponentsResponse(IEnumerable<Database.Component> components)
		{
			Items = components.Select(x => new Component(x));
		}
	}
}

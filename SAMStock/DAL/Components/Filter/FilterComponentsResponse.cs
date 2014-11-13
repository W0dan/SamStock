using System.Collections.Generic;
using System.Linq;
using SAMStock.BO;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsResponse: Response
	{
		public IEnumerable<Component> Components { get; private set; }

		public FilterComponentsResponse(IEnumerable<Database.Component> components)
		{
			Components = components.Select(x => new Component(x));
		}
	}
}

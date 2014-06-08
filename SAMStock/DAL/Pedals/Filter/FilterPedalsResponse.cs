using System.Collections.Generic;
using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsResponse: IFilterResponse<Pedal>
	{
		public IEnumerable<Pedal> Items { get; private set; }

		public FilterPedalsResponse(IEnumerable<Database.Pedal> pedals, decimal defaultpedalprofitmargin)
		{
			Items = pedals.Select(x => new Pedal(x, defaultpedalprofitmargin));
		} 
	}
}

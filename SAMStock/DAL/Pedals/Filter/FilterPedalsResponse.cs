using System.Collections.Generic;
using System.Linq;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsResponse: Response
	{
		public IEnumerable<Pedal> Pedals { get; private set; }

		public FilterPedalsResponse(IEnumerable<Database.Pedal> pedals, decimal defaultpedalprofitmargin)
		{
			Pedals = pedals.Select(x => new Pedal(x, defaultpedalprofitmargin));
		} 
	}
}

using System.Collections.Generic;
using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsResponse: IResponse
	{
		public List<Pedal> Pedals { get; private set; }

		public FilterPedalsResponse(IEnumerable<Database.Pedal> pedals, decimal defaultpedalprofitmargin)
		{
			Pedals = pedals.Select(x => new Pedal(x, defaultpedalprofitmargin)).ToList();
		} 
	}
}

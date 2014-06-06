using System.Collections.Generic;
using System.Linq;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsResponse: IResponse
	{
		public List<BO.Pedal> Pedals { get; private set; }

		public FilterPedalsResponse(IEnumerable<BO.Pedal> pedals)
		{
			Pedals = pedals.ToList();
		} 
	}
}

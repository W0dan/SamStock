using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsRequest: IFilterRequest<Pedal>
	{
		public int? Id { get; set; }
		public int? ComponentId { get; set; }
	}
}

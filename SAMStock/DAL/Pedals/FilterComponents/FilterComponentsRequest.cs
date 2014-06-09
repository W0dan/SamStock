using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.FilterComponents
{
	public class FilterComponentsRequest: IRequest
	{
		public int? PedalId { get; set; }
	}
}

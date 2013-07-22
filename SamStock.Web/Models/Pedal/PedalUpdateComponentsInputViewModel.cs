using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamStock.Web.Models.Pedal
{
	public class PedalUpdateComponentsInputViewModel
	{
		public int Id { get; set; }
		public String Stocknr { get; set; }
		public int Quantity { get; set; }
	}
}
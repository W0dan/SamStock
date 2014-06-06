using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO
{
	public class Pedal
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal ProfitMargin { get; private set; }

		public Pedal(Database.Pedal pedal, decimal defaultprofitmargin)
		{
			Id = pedal.Id;
			Name = pedal.Name;
			Price = pedal.Price;
			ProfitMargin = pedal.ProfitMargin?? defaultprofitmargin;
		}
	}
}

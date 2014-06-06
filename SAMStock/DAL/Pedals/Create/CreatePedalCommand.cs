using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedal.Create
{
	public class CreatePedalCommand : ICommand
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal? ProfitMargin { get; set; }

		public CreatePedalCommand(string name, decimal price)
		{
			Name = name;
			Price = price;
		}
	}
}

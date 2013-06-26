using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.AddPedal
{
	public class AddPedalCommand
	{
		public String Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal Margin { get; private set; }

		public AddPedalCommand(String name, decimal price, decimal margin)
		{
			Name = name;
			Price = price;
			Margin = margin;
		}
	}
}

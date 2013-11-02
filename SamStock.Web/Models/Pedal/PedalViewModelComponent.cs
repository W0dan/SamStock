using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMStock.Pedal.FilterPedal;

namespace SAMStock.Web.Models.Pedal
{
	public class PedalViewModelComponent
	{
		public String Stocknr { get; private set; }
		public String Description { get; private set; }
		public int Quantity { get; private set; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }
		public String ItemCode {get; private set;}
		public String ItemCategory { get; private set; }

		public PedalViewModelComponent(FilterPedalResponseComponent item)
		{
			Stocknr = item.Stocknr;
			Description = item.Description;
			Price = item.Price;
			Quantity = item.Quantity;
			Stock = item.Stock;
			ItemCode = item.ItemCode;
			ItemCategory = toItemCategory(ItemCode);
		}

		private string toItemCategory(string ItemCode)
		{
			switch(ItemCode.Substring(0, 3))
			{
				case "801":
					return "IC";
				case "681":
					return "Hardware02";
				case "802":
					return "Hardware03";
				case "682":
					return "Hardware04";
				case "683":
					return "Hardware05";
				case "684":
					return "Hardware06";
				case "685":
					return "Hardware07";
			}

			String catcode = ItemCode.Substring(0, 2);
			switch (catcode)
			{
				case "26":
					return "IC";
				case "58":
					return "Transistor";
				case "14":
					return "Diode";
				case "38":
					return "LED";
				case "10":
					return "Capacitor";
			}

			int index = Array.IndexOf(new String[]
			{
				"22","30","68","80","68","68","68","68","34","54","18"
			},catcode);
			if (index > -1)
			{
				if (index < 2 || index > 7)
				{
					return "Hardware" + index.ToString("00");
				}
			}


			if (new String[]
			{
				"46","47","48","49","50"
			}.Contains(catcode))
			{
				return "Potentiometer";
			}

			if (new String[]
			{
				"62","63"
			}.Contains(catcode))
			{
				return "Resistor";
			}

			index = Array.IndexOf(new String[]
			{
				"76","42","12","72"
			},catcode);
			if (index > -1)
			{
				return "Special" + index;
			}
			return "Undetermined";
		}
	}
}
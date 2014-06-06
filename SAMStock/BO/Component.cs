using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO
{
	public class Component
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Stock { get; private set; }
		public string StockNumber { get; private set; }
		public decimal Price { get; private set; }
		private int _supplierId;
		public string Remarks { get; private set; }
		public string ItemCode { get; private set; }

		public Component(Database.Component component)
		{
			Id = component.Id;
			Name = component.Name;
			MinimumStock = component.MinimumStock;
			Stock = component.Stock;
			StockNumber = component.StockNumber;
			Price = component.Price;
			_supplierId = component.SupplierId;
			Remarks = component.Remarks;
			ItemCode = component.ItemCode;
		}
	}
}

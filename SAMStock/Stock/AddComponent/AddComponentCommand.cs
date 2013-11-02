using SAMStock.Utilities;
using System;

namespace SAMStock.Stock.AddComponent
{
	public class AddComponentCommand
	{
		private readonly string _name;
		private readonly int _minimumStock;
		private readonly int _quantity;
		private readonly string _stocknr;
		private readonly decimal _price;
		private readonly int _supplierId;
		private readonly string _remark;
		private readonly String _itemcode;

		public AddComponentCommand(string naam, int minimumStock, int hoeveelheid, string stocknr, decimal prijs, int leverancierId, string opmerkingen, String itemcode)
		{
			_name = naam;
			_minimumStock = minimumStock;
			_quantity = hoeveelheid;
			_stocknr = stocknr;
			_price = prijs;
			_supplierId = leverancierId;
			_remark = opmerkingen;
			_itemcode = itemcode;
		}

		public string Name
		{
			get { return _name; }
		}

		public int MinimumStock
		{
			get { return _minimumStock; }
		}

		public int Quantity
		{
			get { return _quantity; }
		}

		public string Stocknr
		{
			get { return _stocknr; }
		}

		public decimal Price
		{
			get { return _price; }
		}

		public int SupplierId
		{
			get { return _supplierId; }
		}

		public string Remarks
		{
			get { return _remark; }
		}

		public String ItemCode
		{
			get { return _itemcode; }
		}
	}
}
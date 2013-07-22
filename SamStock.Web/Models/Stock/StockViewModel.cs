using System.Collections.Generic;
using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockRefdata;

namespace SamStock.Web.Models.Stock
{
	public class StockViewModel
	{
		public readonly decimal _contentTotalValue = 0.00M;
		public List<StockViewModelItem> Components { get; private set; }
		public List<StockViewModelSupplier> Suppliers { get; private set; }

		public StockViewModel()
		{
		}

		private StockViewModel(GetStockRefdataResponse refdata)
		{
			Suppliers = new List<StockViewModelSupplier>();

			foreach (var leverancier in refdata.Suppliers)
			{
				Suppliers.Add(new StockViewModelSupplier(leverancier));
			}
		}

		public StockViewModel(IEnumerable<FilterStockItem> list, GetStockRefdataResponse refdata)
			: this(refdata)
		{
			Components = new List<StockViewModelItem>();

			foreach (var item in list)
			{
				Components.Add(new StockViewModelItem(item));
				_contentTotalValue += item.Quantity * item.Price;
			}
		}

		public StockViewModel(IEnumerable<FilterStockItem> list, GetStockRefdataResponse refdata, decimal totalStockValue)
			: this(refdata)
		{
			Components = new List<StockViewModelItem>();

			foreach (var item in list)
			{
				Components.Add(new StockViewModelItem(item));
			}

			_contentTotalValue = totalStockValue;
		}
	}
}
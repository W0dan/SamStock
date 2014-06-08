using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentCommand: ICreateCommand<Component>
	{
		public string Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Stock { get; set; }
		public string StockNumber { get; private set; }
		public decimal Price { get; private set; }
		public int SupplierId { get; private set; }
		public string Remarks { get; set; }
		public string ItemCode { get; private set; }

		public CreateComponentCommand(string name, int minimumstock, string stocknumber, decimal price, int supplierid, string itemcode)
		{
			Stock = 0;
			Name = name;
			MinimumStock = minimumstock;
			StockNumber = stocknumber;
			Price = price;
			SupplierId = supplierid;
			ItemCode = itemcode;
		}
	}
}

using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentRequest: Request<CreateComponentResponse>
	{
		public string Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Stock { get; set; }
		public string StockNumber { get; private set; }
		public decimal Price { get; private set; }
		public int SupplierId { get; private set; }
		public string Remarks { get; set; }
		public string ItemCode { get; private set; }

		public CreateComponentRequest(object sender, string name, int minimumstock, string stocknumber, decimal price, int supplierid, string itemcode): base(sender)
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

using System;
using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Update
{
	public class UpdateComponentRequest: Request<UpdateComponentResponse>
	{
		public int Id { get; private set; }
		public string Name { get; set; }
		public int? MinimumStock { get; set; }
		public int? Stock { get; set; }
		public string StockNumber { get; set; }
		public decimal? Price { get; set; }
		public int? SupplierId { get; set; }
		public string Remarks { get; set; }
		public string ItemCode { get; set; }

		public UpdateComponentRequest(Object sender, int id): base(sender)
		{
			Id = id;
		}
	}
}

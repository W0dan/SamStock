using System.Collections.Generic;
using System.Linq;
using SAMStock.BO.Base;
using SAMStock.DAL.Pedals.Filter;
using SAMStock.DAL.Suppliers.Filter;

namespace SAMStock.BO
{
	public class Component: IBO
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Stock { get; private set; }
		public string StockNumber { get; private set; }
		public decimal Price { get; private set; }
		private readonly int _supplierId;
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

		public List<Pedal> Pedals
		{
			get { return Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest
			{
				ComponentId = Id
			}).Items.ToList(); }
		}

		public Supplier Supplier
		{
			get
			{
				return Dispatcher.Request<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest
				{
					Id = _supplierId
				}).Items.Single();
			}
		}
	}
}

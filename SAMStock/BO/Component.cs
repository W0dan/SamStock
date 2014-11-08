using System;
using System.Collections.Generic;
using System.Linq;
using SAMStock.BO.Foundation;
using SAMStock.DAL.Pedals.Filter;
using SAMStock.DAL.Suppliers.Filter;
using Util.Collections;

namespace SAMStock.BO
{
	public class Component: BusinessObject
	{
		public string Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Stock { get; private set; }
		public string StockNumber { get; private set; }
		public decimal Price { get; private set; }
		private readonly int _supplierId;
		public string Remarks { get; private set; }
		public string ItemCode { get; private set; }
		public event EventHandler<Component> Deleted;
		public event EventHandler<Component> Updated;

		internal Component(Database.Component component)
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

			Components s = new Singleton<Components>();
			s.Updated += (sender, updated) =>
			{
				if (updated.BO.Id.Equals(Id))
				{
					Update(updated.BO);
				}
			};
			s.Deleted += (sender, deleted) =>
			{
				if (deleted.Id.Equals(Id))
				{
					Delete();
				}
			};
		}

		public List<Pedal> Pedals
		{
			get { return Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest(this)
			{
				ComponentId = Id
			}).Items.ToList(); }
		}

		public Supplier Supplier
		{
			get
			{
				return Dispatcher.Request<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest(this)
				{
					Id = _supplierId
				}).Items.Single();
			}
		}

		private void Delete()
		{
			var handler = Deleted;
			if (handler != null)
			{
				handler(null, this);
			}
		}

		private void Update(Component c)
		{
			var handler = Updated;
			if (handler != null)
			{
				handler(null, this);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using SAMStock.Business.Foundation;
using SAMStock.Business.Managers;
using SAMStock.Castle;
using SAMStock.DAL.Pedals.Filter;
using SAMStock.DAL.Suppliers.Filter;
using Util.Collections;

namespace SAMStock.Business.Objects
{
	public class Component: IBusinessObject
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
		public event EventHandler Deleted = delegate { };
		public event EventHandler<Component> Updated = delegate { };

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

			var mgr = Components.Events;
			mgr.RegisterDelete((x, y) =>
			{
				if (y.BOId.Equals(Id))
				{
					Deleted(x, null);
				}
			});
			mgr.RegisterUpdate((x, y) =>
			{
				if (y.BO.Id.Equals(Id))
				{
					Updated(x, y.BO);
				}
			});
		}

		public List<Pedal> Pedals
		{
			get { return Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest(this)
			{
				ComponentId = Id
			}).Pedals.ToList(); }
		}

		public Supplier Supplier
		{
			get
			{
				return Dispatcher.Request<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest(this)
				{
					Id = _supplierId
				}).Suppliers.Single();
			}
		}
	}
}

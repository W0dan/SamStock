using System;
using System.Collections.Generic;
using System.Linq;
using SAMStock.Business.Foundation;
using SAMStock.Business.Managers;
using SAMStock.DAL.Components.Filter;

namespace SAMStock.Business.Objects
{
	public class Supplier : IBusinessObject
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public Uri Website { get; private set; }
		public string Address { get; private set; }
		public event EventHandler<Supplier> Deleted;
		public event EventHandler<Supplier> Updated;

		internal Supplier(Database.Supplier supplier)
		{
			Id = supplier.Id;
			Name = supplier.Name;
			Website = new Uri(supplier.Website);
			Address = supplier.Address;

			var mgr = Suppliers.Events;
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

		public List<Component> Components
		{
			get
			{
				return Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest(this)
				{
					SupplierId = Id
				}).Components.ToList();
			}
		}
	}
}
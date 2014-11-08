using System;
using System.Collections.Generic;
using System.Linq;
using SAMStock.BO.Foundation;
using SAMStock.DAL.Components.Filter;
using Util.Collections;

namespace SAMStock.BO
{
	public class Supplier : BusinessObject
	{
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

			Suppliers s = new Singleton<Suppliers>();
			s.Deleted += (sender, deleted) =>
			{
				if (deleted.Id.Equals(Id))
				{
					Delete();
				}
			};
			s.Updated += (sender, updated) =>
			{
				if (updated.BO.Id.Equals(Id))
				{
					Update(updated.BO);
				}
			};
		}

		public List<Component> Components
		{
			get
			{
				return Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest(this)
				{
					SupplierId = Id
				}).Items.ToList();
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

		private void Update(Supplier s)
		{
			var handler = Updated;
			if (handler != null)
			{
				handler(null, this);
			}
		}
	}
}

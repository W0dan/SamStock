﻿using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using SAMStock.Utilities;
using Supplier = SAMStock.Business.Objects.Supplier;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierExecutor: BOCommandExecutor<UpdateSupplierCommand, Supplier>
	{
		public UpdateSupplierExecutor(IContext context) : base(context)
		{
		}

		public override Supplier Execute(UpdateSupplierCommand cmd)
		{
			var supplier = Context.Suppliers.Single(x => x.Id == cmd.Id);
			cmd.Name.IfMeaningful(x => supplier.Name = x);
			cmd.Website.IfMeaningful(x => supplier.Website = x);
			cmd.Address.IfMeaningful(x => supplier.Address = x);
			Context.SaveChanges();
			var s = new Supplier(supplier);
			Business.Managers.Suppliers.Manager.TriggerUpdated(s);
			return s;
		}
	}
}

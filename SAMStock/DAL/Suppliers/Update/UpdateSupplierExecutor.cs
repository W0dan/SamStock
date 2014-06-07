using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;
using Supplier = SAMStock.BO.Supplier;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierExecutor: BOCommandExecutor<UpdateSupplierCommand, BO.Supplier>
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
			return new Supplier(supplier);
		}
	}
}

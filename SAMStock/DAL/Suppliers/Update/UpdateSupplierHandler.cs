using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierHandler: BOCommandHandler<UpdateSupplierCommand, BO.Supplier>
	{
		public UpdateSupplierHandler(IBOCommandExecutor<UpdateSupplierCommand, Supplier> executor) : base(executor)
		{
		}
	}
}
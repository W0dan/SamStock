using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Create
{
	public class CreateSupplierHandler: BOCommandHandler<CreateSupplierCommand, BO.Supplier>
	{
		public CreateSupplierHandler(IBOCommandExecutor<CreateSupplierCommand, Supplier> executor) : base(executor)
		{
		}
	}
}

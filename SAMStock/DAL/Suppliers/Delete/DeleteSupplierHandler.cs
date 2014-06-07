using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Delete
{
	public class DeleteSupplierHandler: CommandHandler<DeleteSupplierCommand>
	{
		public DeleteSupplierHandler(ICommandExecutor<DeleteSupplierCommand> executor) : base(executor)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommandHandler: IDeleteSupplierCommandHandler
	{
		private readonly IDeleteSupplierCommandExecutor _executor;

		public DeleteSupplierCommandHandler(IDeleteSupplierCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeleteSupplierCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}

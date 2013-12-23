using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Supplier.UpdateSupplier
{
	public class UpdateSupplierCommandHandler: IUpdateSupplierCommandHandler
	{
		private readonly IUpdateSupplierCommandExecutor _executor;

		public UpdateSupplierCommandHandler(IUpdateSupplierCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(UpdateSupplierCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}

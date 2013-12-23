using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Supplier.DeleteSupplier
{
	public interface IDeleteSupplierCommandExecutor
	{
		void Execute(DeleteSupplierCommand cmd);
	}
}

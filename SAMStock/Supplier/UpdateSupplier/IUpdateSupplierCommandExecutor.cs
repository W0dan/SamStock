using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Supplier.UpdateSupplier
{
	public interface IUpdateSupplierCommandExecutor
	{
		void Execute(UpdateSupplierCommand cmd);
	}
}

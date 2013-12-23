using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Supplier.DeleteSupplier
{
	public interface IDeleteSupplierCommandHandler: ICommandHandler<DeleteSupplierCommand>
	{
		new void Handle(DeleteSupplierCommand cmd);
	}
}

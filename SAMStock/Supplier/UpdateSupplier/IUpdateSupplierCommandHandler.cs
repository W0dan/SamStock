using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Supplier.UpdateSupplier
{
	public interface IUpdateSupplierCommandHandler: ICommandHandler<UpdateSupplierCommand>
	{
		new void Handle(UpdateSupplierCommand cmd);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.Supplier.UpdateSupplier
{
	public class UpdateSupplierCommandExecutor: IUpdateSupplierCommandExecutor
	{
		private readonly IContext _context;

		public UpdateSupplierCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdateSupplierCommand cmd)
		{
			var supplier = _context.Supplier.Single(x => x.Id == cmd.Id);
			if (!cmd.Address.IsNullOrEmpty()) supplier.Address = cmd.Address;
			if (!cmd.Name.IsNullOrEmpty()) supplier.Name = cmd.Name;
			if (!cmd.Website.IsNullOrEmpty()) supplier.Website = cmd.Website;
		}
	}
}

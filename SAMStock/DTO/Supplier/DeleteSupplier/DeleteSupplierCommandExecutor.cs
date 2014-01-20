using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommandExecutor: IDeleteSupplierCommandExecutor
	{
		private readonly IContext _context;

		public DeleteSupplierCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(DeleteSupplierCommand cmd)
		{
			_context.Supplier.DeleteObject(_context.Supplier.Single(x => x.Id == cmd.Id));
		}
	}
}

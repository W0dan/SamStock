using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommandExecutor: CommandExecutor<DeleteSupplierCommand>
	{
		public DeleteSupplierCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(DeleteSupplierCommand cmd)
		{
			Context.Supplier.DeleteObject(Context.Supplier.Single(x => x.Id == cmd.Id));
		}
	}
}

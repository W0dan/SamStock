using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Delete
{
	public class DeleteSupplierHandler: CommandHandler<DeleteSupplierCommand>
	{
		public DeleteSupplierHandler(ICommandExecutor<DeleteSupplierCommand> executor) : base(executor)
		{
		}
	}
}

namespace SAMStock.DAL.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommandHandler: CommandHandler<DeleteSupplierCommand>
	{
		public DeleteSupplierCommandHandler(ICommandExecutor<DeleteSupplierCommand> executor): base(executor)
		{
		}
	}
}

namespace SAMStock.DTO.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommandHandler: CommandHandler<DeleteSupplierCommand>
	{
		public DeleteSupplierCommandHandler(ICommandExecutor<DeleteSupplierCommand> executor): base(executor)
		{
		}
	}
}

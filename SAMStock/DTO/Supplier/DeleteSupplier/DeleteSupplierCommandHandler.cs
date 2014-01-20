namespace SAMStock.DTO.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommandHandler: IDeleteSupplierCommandHandler
	{
		private readonly IDeleteSupplierCommandExecutor _executor;

		public DeleteSupplierCommandHandler(IDeleteSupplierCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeleteSupplierCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}

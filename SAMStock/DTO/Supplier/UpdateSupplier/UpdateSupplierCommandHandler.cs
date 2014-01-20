namespace SAMStock.DTO.Supplier.UpdateSupplier
{
	public class UpdateSupplierCommandHandler: IUpdateSupplierCommandHandler
	{
		private readonly IUpdateSupplierCommandExecutor _executor;

		public UpdateSupplierCommandHandler(IUpdateSupplierCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(UpdateSupplierCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}

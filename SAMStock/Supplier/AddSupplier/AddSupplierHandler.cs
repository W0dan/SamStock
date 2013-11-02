namespace SAMStock.Supplier.AddSupplier
{
	public class AddSupplierHandler : IAddSupplierHandler
	{
		private readonly IAddSupplierCommandExecutor _addLeverancierCommandExecutor;

		public AddSupplierHandler(IAddSupplierCommandExecutor addLeverancierCommandExecutor)
		{
			_addLeverancierCommandExecutor = addLeverancierCommandExecutor;
		}

		public void Handle(AddSupplierCommand command)
		{
			_addLeverancierCommandExecutor.Execute(command);
		}
	}
}
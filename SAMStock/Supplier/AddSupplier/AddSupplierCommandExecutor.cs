using SAMStock.Database;

namespace SAMStock.Supplier.AddSupplier
{
	public class AddSupplierCommandExecutor : IAddSupplierCommandExecutor
	{
		private readonly IContext _context;

		public AddSupplierCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(AddSupplierCommand command)
		{
			_context.Supplier.AddObject(new Database.Supplier
			{
				Name = command.Name,
				Address = command.Address,
				Website = command.Website
			});
		}
	}
}
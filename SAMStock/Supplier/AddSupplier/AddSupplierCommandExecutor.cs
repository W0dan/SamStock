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
			var leverancier = new SAMStock.Database.Supplier
				{
					Name = command.Name,
					Address = command.Address,
					Website = command.Website
				};

			_context.Supplier.AddObject(leverancier);
		}
	}
}
using SamStock.Database;

namespace SamStock.Supplier.AddSupplier
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
			var leverancier = new SamStock.Database.Supplier
				{
					Name = command.Name,
					Address = command.Address,
					Website = command.Website
				};

			_context.Supplier.AddObject(leverancier);
		}
	}
}
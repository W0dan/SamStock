using SAMStock.Database;

namespace SAMStock.DTO.Supplier.AddSupplier
{
	public class AddSupplierCommandExecutor : CommandExecutor<AddSupplierCommand>
	{
		public AddSupplierCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(AddSupplierCommand command)
		{
			Context.Supplier.AddObject(new Database.Supplier
			{
				Name = command.Name,
				Address = command.Address,
				Website = command.Website
			});
		}
	}
}
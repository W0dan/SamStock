using SAMStock.Database;

namespace SAMStock.Component.AddComponent
{
	public class AddComponentCommandExecutor : IAddComponentCommandExecutor
	{
		private readonly IContext _context;

		public AddComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(AddComponentCommand command)
		{
			var component = new Database.Component
				{
					Name = command.Name,
					MinimumStock = command.MinimumStock,
					Stock = command.Quantity,
					Stocknr = command.Stocknr,
					Price = command.Price,
					SupplierId = command.SupplierId,
					Remarks = command.Remarks,
					ItemCode = command.ItemCode
				};

			_context.Component.AddObject(component);
		}
	}
}
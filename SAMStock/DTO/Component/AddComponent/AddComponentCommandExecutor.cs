using SAMStock.Database;
using SAMStock.DTO.Component.AddComponent.Exceptions;

namespace SAMStock.DTO.Component.AddComponent
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
			if (command.ItemCode.Length == 7)
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
			else
			{
				throw new ComponentItemCodeIllegalLengthException();
			}
		}
	}
}
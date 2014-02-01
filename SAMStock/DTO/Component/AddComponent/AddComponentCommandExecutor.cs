using SAMStock.Database;
using SAMStock.DTO.Component.AddComponent.Exceptions;

namespace SAMStock.DTO.Component.AddComponent
{
	public class AddComponentCommandExecutor : CommandExecutor<AddComponentCommand>
	{
		public AddComponentCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(AddComponentCommand command)
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
				Context.Component.AddObject(component);
			}
			else
			{
				throw new ComponentItemCodeIllegalLengthException();
			}
		}
	}
}
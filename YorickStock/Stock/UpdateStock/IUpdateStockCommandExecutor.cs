using SamStock.Utilities;

namespace SamStock.Stock.UpdateStock
{
	public interface IUpdateStockCommandExecutor : ICommandExecutor
	{
		void Execute(UpdateStockCommand command);
	}
}
using SAMStock.Utilities;

namespace SAMStock.Stock.UpdateStock
{
	public interface IUpdateStockCommandExecutor : ICommandExecutor
	{
		void Execute(UpdateStockCommand command);
	}
}
using SAMStock.Utilities;

namespace SAMStock.DTO.Component.UpdateComponent
{
	public interface IUpdateStockCommandExecutor : IQuery
	{
		void Execute(UpdateComponentCommand cmd);
	}
}

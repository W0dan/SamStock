using SAMStock.Utilities;

namespace SAMStock.Stock.AddComponent
{
	public interface IAddComponentCommandExecutor : ICommandExecutor
	{
		void Execute(AddComponentCommand command);
	}
}
using SamStock.Utilities;

namespace SamStock.Stock.AddComponent
{
	public interface IAddComponentCommandExecutor : ICommandExecutor
	{
		void Execute(AddComponentCommand command);
	}
}
using SAMStock.Utilities;

namespace SAMStock.Component.AddComponent
{
	public interface IAddComponentCommandExecutor : ICommandExecutor
	{
		void Execute(AddComponentCommand command);
	}
}
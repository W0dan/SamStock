using SAMStock.Utilities;

namespace SAMStock.DTO.Component.AddComponent
{
	public interface IAddComponentCommandExecutor : ICommandExecutor
	{
		void Execute(AddComponentCommand command);
	}
}
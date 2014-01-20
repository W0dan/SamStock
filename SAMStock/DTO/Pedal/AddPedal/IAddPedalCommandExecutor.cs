using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.AddPedal
{
	public interface IAddPedalCommandExecutor : ICommandExecutor
	{
		void Execute(AddPedalCommand cmd);
	}
}

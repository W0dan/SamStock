using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.UpdatePedal
{
	public interface IUpdatePedalCommandExecutor : ICommandExecutor
	{
		void Execute(UpdatePedalCommand cmd);
	}
}

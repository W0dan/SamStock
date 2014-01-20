using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.UpdatePedal
{
	public interface IUpdatePedalCommandHandler : ICommandHandler<UpdatePedalCommand>
	{
		new void Handle(UpdatePedalCommand cmd);
	}
}

using SAMStock.Utilities;

namespace SAMStock.Pedal.UpdatePedal
{
	public interface IUpdatePedalCommandHandler : ICommandHandler<UpdatePedalCommand>
	{
		new void Handle(UpdatePedalCommand cmd);
	}
}

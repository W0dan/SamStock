using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.DeletePedal
{
	public interface IDeletePedalCommandHandler: ICommandHandler<DeletePedalCommand>
	{
		new void Handle(DeletePedalCommand cmd);
	}
}

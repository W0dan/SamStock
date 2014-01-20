using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.DeleteComponent
{
	public interface IDeleteComponentCommandHandler: ICommandHandler<DeleteComponentCommand>
	{
		new void Handle(DeleteComponentCommand cmd);
	}
}

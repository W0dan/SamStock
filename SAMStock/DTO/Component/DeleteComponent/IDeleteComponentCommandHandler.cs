using SAMStock.Utilities;

namespace SAMStock.DTO.Component.DeleteComponent
{
	public interface IDeleteComponentCommandHandler: ICommandHandler<DeleteComponentCommand>
	{
		new void Handle(DeleteComponentCommand cmd);
	}
}

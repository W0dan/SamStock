using SAMStock.Utilities;

namespace SAMStock.DTO.Component.UpdateComponent
{
	public interface IUpdateComponentHandler : ICommandHandler<UpdateComponentCommand>
	{
		new void Handle(UpdateComponentCommand cmd);
	}
}

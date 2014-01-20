using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.UpdateComponent
{
	interface IUpdateComponentCommandHandler: ICommandHandler<UpdateComponentCommand>
	{
		new void Handle(UpdateComponentCommand cmd);
	}
}

using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.AddComponent
{
	public interface IAddComponentCommandHandler: ICommandHandler<AddComponentCommand>
	{
		new void Handle(AddComponentCommand cmd);
	}
}

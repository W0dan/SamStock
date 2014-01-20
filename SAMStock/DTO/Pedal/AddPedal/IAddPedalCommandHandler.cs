using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.AddPedal
{
	public interface IAddPedalCommandHandler : ICommandHandler<AddPedalCommand>
	{
		new void Handle(AddPedalCommand cmd);
	}
}
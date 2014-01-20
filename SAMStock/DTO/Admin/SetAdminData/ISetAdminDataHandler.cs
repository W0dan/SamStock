using SAMStock.Utilities;

namespace SAMStock.DTO.Admin.SetAdminData
{
	public interface ISetAdminDataHandler : ICommandHandler<SetAdminDataCommand>
	{
		new void Handle(SetAdminDataCommand command);
	}
}

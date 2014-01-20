using SAMStock.Utilities;

namespace SAMStock.DTO.Admin.SetAdminData
{
	public interface ISetAdminDataCommandExecutor : IQuery
	{
		void Execute(SetAdminDataCommand cmd);
	}
}

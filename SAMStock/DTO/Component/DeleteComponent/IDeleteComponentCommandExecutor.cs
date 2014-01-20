using SAMStock.Utilities;

namespace SAMStock.DTO.Component.DeleteComponent
{
	public interface IDeleteComponentCommandExecutor: IQuery
	{
		void Execute(DeleteComponentCommand cmd);
	}
}

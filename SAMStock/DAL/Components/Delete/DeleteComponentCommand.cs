using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentCommand: IDeleteCommand<Component>
	{
		public int Id { get; private set; }
		public bool Cascade { get; set; }

		public DeleteComponentCommand(int id)
		{
			Id = id;
			Cascade = false;
		}
	}
}

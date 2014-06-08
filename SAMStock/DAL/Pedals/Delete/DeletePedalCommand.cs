using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Delete
{
	public class DeletePedalCommand: IDeleteCommand<Pedal>
	{
		public int Id { get; private set; }

		public DeletePedalCommand(int id)
		{
			Id = id;
		}
	}
}

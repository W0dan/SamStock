using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Update
{
	public class UpdatePedalCommand: IBOCommand<BO.Pedal>
	{
		public int Id { get; private set; }
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public decimal? ProfitMargin { get; set; }

		public UpdatePedalCommand(int id)
		{
			Id = id;
		}
	}
}

using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Create
{
	public class CreatePedalCommand : IBOCommand<BO.Pedal>
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal? ProfitMargin { get; set; }

		public CreatePedalCommand(string name, decimal price)
		{
			Name = name;
			Price = price;
		}
	}
}

using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Create
{
	public class CreatePedalCommand : ICreateCommand<Pedal>
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

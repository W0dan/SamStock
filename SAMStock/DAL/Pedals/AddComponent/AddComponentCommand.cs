using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.AddComponent
{
	public class AddComponentCommand: IUpdateCommand<Pedal>
	{
		public int PedalId { get; private set; }
		public int ComponentId { get; private set; }
		public int Amount { get; private set; }

		public AddComponentCommand(int pedalid, int componentid, int amount)
		{
			PedalId = pedalid;
			ComponentId = componentid;
			Amount = amount;
		}
	}
}

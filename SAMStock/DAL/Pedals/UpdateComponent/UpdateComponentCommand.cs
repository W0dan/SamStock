using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.UpdateComponent
{
	public class UpdateComponentCommand: IUpdateCommand<Pedal>
	{
		public int ComponentId { get; private set; }
		public int PedalId { get; private set; }
		public int Amount { get; private set; }

		public UpdateComponentCommand(int componentid, int pedalid, int amount)
		{
			PedalId = pedalid;
			ComponentId = componentid;
			Amount = amount;
		}
	}
}

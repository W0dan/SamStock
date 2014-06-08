using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.AddComponent
{
	public class AddComponentCommand: ICommand
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

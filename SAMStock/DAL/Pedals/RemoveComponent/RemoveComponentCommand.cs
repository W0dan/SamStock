using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.RemoveComponent
{
	public class RemoveComponentCommand: ICommand
	{
		public int ComponentId { get; private set; }
		public int PedalId { get; private set; }

		public RemoveComponentCommand(int componentid, int pedalid)
		{
			ComponentId = componentid;
			PedalId = pedalid;
		}
	}
}

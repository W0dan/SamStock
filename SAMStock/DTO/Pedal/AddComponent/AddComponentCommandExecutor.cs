using SAMStock.Database;

namespace SAMStock.DTO.Pedal.AddComponent
{
	public class AddComponentCommandExecutor: IAddComponentCommandExecutor
	{
		private readonly IContext _context;

		public AddComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(AddComponentCommand cmd)
		{
			_context.PedalComponent.AddObject(new PedalComponent
			{
				PedalId = cmd.PedalId,
				ComponentId = cmd.ComponentId,
				Number = cmd.Quantity
			});
		}
	}
}

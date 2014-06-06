using SAMStock.Database;

namespace SAMStock.DAL.Pedal.AddComponent
{
	public class AddComponentCommandExecutor: CommandExecutor<AddComponentCommand>
	{
		public AddComponentCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(AddComponentCommand cmd)
		{
			Context.PedalComponent.AddObject(new PedalComponent
			{
				PedalId = cmd.PedalId,
				ComponentId = cmd.ComponentId,
				Number = cmd.Quantity
			});
		}
	}
}

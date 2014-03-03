using SAMStock.Database;

namespace SAMStock.DAL.Pedal.AddPedal
{
	public class AddPedalCommandExecutor : CommandExecutor<AddPedalCommand>
	{
		public AddPedalCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(AddPedalCommand cmd)
		{
			Context.Pedal.AddObject(new Database.Pedal
			{
				Name = cmd.Name,
				Price = cmd.Price,
				Margin = cmd.Margin
			});
		}
	}
}

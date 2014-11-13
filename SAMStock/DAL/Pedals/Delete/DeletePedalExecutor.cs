using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using Pedal = SAMStock.Business.Objects.Pedal;

namespace SAMStock.DAL.Pedals.Delete
{
	public class DeletePedalExecutor: CommandExecutor<DeletePedalCommand>
	{
		public DeletePedalExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(DeletePedalCommand cmd)
		{
			var pedal = Context.Pedals.Single(x => x.Id == cmd.Id);
			Context.Pedals.Remove(pedal);
			Context.SaveChanges();
			Business.Managers.Pedals.Manager.TriggerDeleted(pedal.Id);
			return pedal.Id;
		}
	}
}

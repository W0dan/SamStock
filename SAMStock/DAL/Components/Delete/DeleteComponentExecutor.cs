using System.Linq;
using Castle.Core.Internal;
using SAMStock.Castle;
using SAMStock.DAL.Foundation;
using SAMStock.Database;

namespace SAMStock.DAL.Components.Delete
{
	class DeleteComponentExecutor: Executor<DeleteComponentRequest, DeleteComponentResponse>
	{
		public DeleteComponentExecutor(IContext context) : base(context)
		{
		}

		public override DeleteComponentResponse Execute(DeleteComponentRequest cmd)
		{
			var component = Context.Components.Single(x => x.Id == cmd.Id);
			if (component.ComponentsOfPedals.Any() && cmd.Cascade)
			{
				component.ComponentsOfPedals.ForEach(x => Context.ComponentsOfPedals.Remove(x));
				Context.SaveChanges();
			}
			Context.Components.Remove(component);
			Context.SaveChanges();
			IoC.Instance.Resolve<Business.Managers.Components>().Delete(cmd.Id);
			return new DeleteComponentResponse(cmd.Id);
		}
	}
}
using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Update
{
	public class UpdateComponentHandler: BOCommandHandler<UpdateComponentRequest, Component>
	{
		public UpdateComponentHandler(IBOCommandExecutor<UpdateComponentRequest, Component> executor) : base(executor)
		{
		}
	}
}

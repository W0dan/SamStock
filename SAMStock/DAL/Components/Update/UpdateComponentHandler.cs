using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Update
{
	public class UpdateComponentHandler: BOCommandHandler<UpdateComponentCommand, Component>
	{
		public UpdateComponentHandler(IBOCommandExecutor<UpdateComponentCommand, Component> executor) : base(executor)
		{
		}
	}
}

using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentHandler: BOCommandHandler<CreateComponentCommand, Component>
	{
		public CreateComponentHandler(IBOCommandExecutor<CreateComponentCommand, Component> executor) : base(executor)
		{
		}
	}
}

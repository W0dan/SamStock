using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentHandler: BOCommandHandler<CreateComponentRequest, Component>
	{
		public CreateComponentHandler(IBOCommandExecutor<CreateComponentRequest, Component> executor) : base(executor)
		{
		}
	}
}

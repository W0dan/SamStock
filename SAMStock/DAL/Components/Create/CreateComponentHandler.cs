using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Create
{
	class CreateComponentHandler: Handler<CreateComponentRequest, CreateComponentResponse>
	{
		public CreateComponentHandler(IExecutor<CreateComponentRequest, CreateComponentResponse> executor) : base(executor)
		{
		}
	}
}
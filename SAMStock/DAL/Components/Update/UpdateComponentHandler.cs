using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Update
{
	class UpdateComponentHandler: Handler<UpdateComponentRequest, UpdateComponentResponse>
	{
		public UpdateComponentHandler(IExecutor<UpdateComponentRequest, UpdateComponentResponse> executor) : base(executor)
		{
		}
	}
}

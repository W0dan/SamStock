using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Delete
{
	class DeleteComponentHandler: Handler<DeleteComponentRequest, DeleteComponentResponse>
	{
		public DeleteComponentHandler(IExecutor<DeleteComponentRequest, DeleteComponentResponse> executor) : base(executor)
		{
		}
	}
}

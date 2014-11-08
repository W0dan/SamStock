using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Foundation
{
	public interface IRequestExecutor<in TRequest, out TResponse> where TRequest: IRequest<TResponse> where TResponse: IResponse
	{
	    TResponse Execute(TRequest req);
    }
}
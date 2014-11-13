using SAMStock.Castle;

namespace SAMStock.DAL.Foundation
{
	public interface IHandler<in TRequest, out TResponse> where TRequest: IRequest<TResponse> where TResponse: IResponse
    {
        TResponse Handle(TRequest request);
    }
}
namespace SamStock.Utilities
{
    public interface IDispatcher
    {
        TResponse DispatchRequest<TRequest, TResponse>(TRequest request);
        void DispatchCommand<TCommand>(TCommand command);
    }
}
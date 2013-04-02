namespace SamStock.Utilities
{
    public interface IDispatcher
    {
        TResponse DispatchQuery<TRequest, TResponse>(TRequest request);
        void DispatchCommand<TCommand>(TCommand command);
    }
}
namespace SAMStock.DTO
{
    public interface IRequestExecutor<in TRequest, out TResponse>
    {
	    TResponse Execute(TRequest req);
    }
}
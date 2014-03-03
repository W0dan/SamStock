namespace SAMStock.DAL
{
    public interface IRequestExecutor<in TRequest, out TResponse>
    {
	    TResponse Execute(TRequest req);
    }
}
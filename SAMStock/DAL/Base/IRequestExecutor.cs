namespace SAMStock.DAL.Base
{
	public interface IRequestExecutor<in TRequest, out TResponse>
    {
	    TResponse Execute(TRequest req);
    }
}
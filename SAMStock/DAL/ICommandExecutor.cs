namespace SAMStock.DAL
{
    public interface ICommandExecutor<in TCommand>
    {
	    int Execute(TCommand cmd);
    }
}
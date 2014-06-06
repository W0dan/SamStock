namespace SAMStock.DAL.Base
{
    public interface ICommandExecutor<in TCommand>
    {
	    int Execute(TCommand cmd);
    }
}
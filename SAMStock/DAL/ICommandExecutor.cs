namespace SAMStock.DAL
{
    public interface ICommandExecutor<in TCommand>
    {
	    void Execute(TCommand cmd);
    }
}
namespace SAMStock.DTO
{
    public interface ICommandExecutor<in TCommand>
    {
	    void Execute(TCommand cmd);
    }
}
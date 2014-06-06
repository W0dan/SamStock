namespace SAMStock.DAL
{
    public interface ICommandHandler<in TCommand>
    {
        int Handle(TCommand command);
    }
}
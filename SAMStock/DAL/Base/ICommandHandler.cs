namespace SAMStock.DAL.Base
{
    public interface ICommandHandler<in TCommand>
    {
        int Handle(TCommand command);
    }
}
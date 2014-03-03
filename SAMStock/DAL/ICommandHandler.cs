namespace SAMStock.DAL
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
namespace SAMStock.Utilities
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
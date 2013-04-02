namespace SamStock.Utilities
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
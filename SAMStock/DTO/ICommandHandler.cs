namespace SAMStock.DTO
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
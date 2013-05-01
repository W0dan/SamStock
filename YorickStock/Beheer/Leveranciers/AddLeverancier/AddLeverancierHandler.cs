namespace SamStock.Beheer.Leveranciers.AddLeverancier
{
    public class AddLeverancierHandler : IAddLeverancierHandler
    {
        private readonly IAddLeverancierCommandExecutor _addLeverancierCommandExecutor;

        public AddLeverancierHandler(IAddLeverancierCommandExecutor addLeverancierCommandExecutor)
        {
            _addLeverancierCommandExecutor = addLeverancierCommandExecutor;
        }

        public void Handle(AddLeverancierCommand command)
        {
            _addLeverancierCommandExecutor.Execute(command);
        }
    }
}
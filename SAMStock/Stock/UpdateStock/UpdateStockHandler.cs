namespace SAMStock.Stock.UpdateStock
{
    public class UpdateStockHandler:IUpdateStockHandler
    {
        private IUpdateStockCommandExecutor _commandExecutor;
        public UpdateStockHandler(IUpdateStockCommandExecutor updateStockCommandExecutor)
        {
            _commandExecutor = updateStockCommandExecutor;
        }

        public void Handle(UpdateStockCommand command)
        {
            _commandExecutor.Execute(command);
        }
    }
}
using SamStock.Utilities;

namespace SamStock.Stock.ComponentToevoegen
{
    public interface IComponentToevoegenCommandExecutor : ICommandExecutor
    {
        void Execute(ComponentToevoegenCommand command);
    }
}
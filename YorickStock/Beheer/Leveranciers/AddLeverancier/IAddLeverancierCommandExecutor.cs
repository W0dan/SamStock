using SamStock.Utilities;

namespace SamStock.Beheer.Leveranciers.AddLeverancier
{
    public interface IAddLeverancierCommandExecutor:ICommandExecutor
    {
        void Execute(AddLeverancierCommand command);
    }
}
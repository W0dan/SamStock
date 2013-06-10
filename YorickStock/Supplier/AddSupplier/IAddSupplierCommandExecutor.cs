using SamStock.Utilities;

namespace SamStock.Supplier.AddSupplier
{
    public interface IAddSupplierCommandExecutor:ICommandExecutor
    {
        void Execute(AddSupplierCommand command);
    }
}
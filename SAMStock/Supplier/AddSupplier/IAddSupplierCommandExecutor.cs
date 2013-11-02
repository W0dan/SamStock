using SAMStock.Utilities;

namespace SAMStock.Supplier.AddSupplier
{
    public interface IAddSupplierCommandExecutor:ICommandExecutor
    {
        void Execute(AddSupplierCommand command);
    }
}
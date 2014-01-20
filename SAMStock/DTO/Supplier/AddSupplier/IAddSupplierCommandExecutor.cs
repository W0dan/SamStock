using SAMStock.Utilities;

namespace SAMStock.DTO.Supplier.AddSupplier
{
    public interface IAddSupplierCommandExecutor:ICommandExecutor
    {
        void Execute(AddSupplierCommand command);
    }
}
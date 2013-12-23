using SAMStock.Utilities;

namespace SAMStock.Supplier.AddSupplier
{
    public interface IAddSupplierHandler : ICommandHandler<AddSupplierCommand>
    {
	    new void Handle(AddSupplierCommand cmd);
    }
}
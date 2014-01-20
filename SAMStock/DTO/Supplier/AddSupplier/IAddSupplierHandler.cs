using SAMStock.Utilities;

namespace SAMStock.DTO.Supplier.AddSupplier
{
    public interface IAddSupplierHandler : ICommandHandler<AddSupplierCommand>
    {
	    new void Handle(AddSupplierCommand cmd);
    }
}
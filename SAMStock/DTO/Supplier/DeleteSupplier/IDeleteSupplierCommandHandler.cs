using SAMStock.Utilities;

namespace SAMStock.DTO.Supplier.DeleteSupplier
{
	public interface IDeleteSupplierCommandHandler: ICommandHandler<DeleteSupplierCommand>
	{
		new void Handle(DeleteSupplierCommand cmd);
	}
}

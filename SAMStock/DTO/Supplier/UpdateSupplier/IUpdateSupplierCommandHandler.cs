using SAMStock.Utilities;

namespace SAMStock.DTO.Supplier.UpdateSupplier
{
	public interface IUpdateSupplierCommandHandler: ICommandHandler<UpdateSupplierCommand>
	{
		new void Handle(UpdateSupplierCommand cmd);
	}
}

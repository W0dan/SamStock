using SAMStock.BO;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Create
{
	public class CreateSupplierHandler: BOCommandHandler<CreateSupplierCommand, Supplier>
	{
		public CreateSupplierHandler(IBOCommandExecutor<CreateSupplierCommand, Supplier> executor) : base(executor)
		{
		}
	}
}

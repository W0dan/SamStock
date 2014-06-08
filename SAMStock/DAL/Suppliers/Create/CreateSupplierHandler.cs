using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Create
{
	public class CreateSupplierHandler: BOCommandHandler<CreateSupplierCommand, Supplier>
	{
		public CreateSupplierHandler(IBOCommandExecutor<CreateSupplierCommand, Supplier> executor) : base(executor)
		{
		}
	}
}

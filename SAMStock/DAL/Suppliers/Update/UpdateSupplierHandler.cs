using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierHandler: BOCommandHandler<UpdateSupplierCommand, Supplier>
	{
		public UpdateSupplierHandler(IBOCommandExecutor<UpdateSupplierCommand, Supplier> executor) : base(executor)
		{
		}
	}
}
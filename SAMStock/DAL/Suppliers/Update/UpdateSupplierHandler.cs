using SAMStock.BO;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierHandler: BOCommandHandler<UpdateSupplierCommand, Supplier>
	{
		public UpdateSupplierHandler(IBOCommandExecutor<UpdateSupplierCommand, Supplier> executor) : base(executor)
		{
		}
	}
}
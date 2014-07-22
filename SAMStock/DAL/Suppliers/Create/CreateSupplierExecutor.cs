using SAMStock.DAL.Base;
using SAMStock.Database;
using Supplier = SAMStock.BO.Supplier;

namespace SAMStock.DAL.Suppliers.Create
{
	public class CreateSupplierExecutor: BOCommandExecutor<CreateSupplierCommand, Supplier>
	{
		public CreateSupplierExecutor(IContext context) : base(context)
		{
		}

		public override Supplier Execute(CreateSupplierCommand cmd)
		{
			var supplier = new Database.Supplier
			{
				Name = cmd.Name,
				Address = cmd.Address,
				Website = cmd.Website
			};
			Context.Suppliers.Add(supplier);
			Context.SaveChanges();
			var s = new Supplier(supplier);
			return s;
		}
	}
}

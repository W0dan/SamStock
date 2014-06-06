using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.DAL.Supplier.UpdateSupplier
{
	public class UpdateSupplierCommandExecutor: CommandExecutor<UpdateSupplierCommand>
	{
		public UpdateSupplierCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(UpdateSupplierCommand cmd)
		{
			var supplier = Context.Supplier.Single(x => x.Id == cmd.Id);
			if (!cmd.Address.IsNullOrEmpty()) supplier.Address = cmd.Address;
			if (!cmd.Name.IsNullOrEmpty()) supplier.Name = cmd.Name;
			if (!cmd.Website.IsNullOrEmpty()) supplier.Website = cmd.Website;
		}
	}
}

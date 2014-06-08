using System.Linq;
using Castle.Core.Internal;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Exceptions;

namespace SAMStock.DAL.Suppliers.Delete
{
	public class DeleteSupplierExecutor: CommandExecutor<DeleteSupplierCommand>
	{
		public DeleteSupplierExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(DeleteSupplierCommand cmd)
		{
			var supplier = Context.Suppliers.Single(x => x.Id == cmd.Id);
			if (supplier.Components.Any())
			{
				if (cmd.Cascade)
				{
					supplier.Components.ForEach(x => Context.Components.Remove(x));
				}
				else
				{
					throw new ForeignKeyException(supplier.Id, supplier.Components.Select(x => x.Id), "Components");
				}
			}
			Context.Suppliers.Remove(supplier);
			Context.SaveChanges();
			BO.Suppliers.TriggerDeleted(cmd, supplier.Id);
			return supplier.Id;
		}
	}
}

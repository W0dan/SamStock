using System.Linq;
using Castle.Core.Internal;
using SAMStock.DAL.Component.UpdateComponent.Exceptions;
using SAMStock.Database;

namespace SAMStock.DAL.Component.UpdateComponent
{
	public class UpdateComponentCommandExecutor: CommandExecutor<UpdateComponentCommand>
	{
		public UpdateComponentCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(UpdateComponentCommand cmd)
		{
			var comp = Context.Component.Single(x => x.Id == cmd.Id);
				if (cmd.ItemCode != null)
				{
					if (cmd.ItemCode.Length == 7)
					{
						comp.ItemCode = cmd.ItemCode;
					} else
					{
						throw new ComponentItemCodeIllegalLengthException();
					}
				}
			if (cmd.Name != null) comp.Name = cmd.Name;
			if (cmd.Remarks != null) comp.Remarks = cmd.Remarks;
			if (cmd.Stocknr != null) comp.Stocknr = cmd.Stocknr;
			if (cmd.MinimumStock.HasValue) comp.MinimumStock = cmd.MinimumStock.Value;
			if (cmd.Price.HasValue) comp.Price = cmd.Price.Value;
			if (cmd.Quantity.HasValue) comp.Stock = cmd.Quantity.Value;
			if (cmd.SupplierId.HasValue) comp.SupplierId = cmd.SupplierId.Value;
		}
	}
}

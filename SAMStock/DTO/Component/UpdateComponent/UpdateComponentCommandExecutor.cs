using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;
using SAMStock.DTO.Component.UpdateComponent.Exceptions;

namespace SAMStock.DTO.Component.UpdateComponent
{
	public class UpdateComponentCommandExecutor: IUpdateStockCommandExecutor
	{
		private readonly IContext _context;

		public UpdateComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdateComponentCommand cmd)
		{
			var comp = _context.Component.Single(x => x.Id == cmd.Id);
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

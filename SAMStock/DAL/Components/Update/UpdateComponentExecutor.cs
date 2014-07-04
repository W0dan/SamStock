using System.Linq;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;
using Component = SAMStock.BO.Component;

namespace SAMStock.DAL.Components.Update
{
	public class UpdateComponentExecutor: BOCommandExecutor<UpdateComponentCommand, Component>
	{
		public UpdateComponentExecutor(IContext context) : base(context)
		{
		}

		public override Component Execute(UpdateComponentCommand cmd)
		{
			var component = Context.Components.Single(x => x.Id == cmd.Id);
			cmd.ItemCode.IfMeaningful(x => component.ItemCode = x);
			cmd.MinimumStock.IfNotNull(x => component.MinimumStock = x);
			cmd.Name.IfMeaningful(x => component.Name = x);
			cmd.Price.IfNotNull(x => component.Price = x);
			cmd.Remarks.IfMeaningful(x => component.Remarks = x);
			cmd.Stock.IfNotNull(x => component.Stock = x);
			cmd.StockNumber.IfMeaningful(x => component.StockNumber = x);
			cmd.SupplierId.IfNotNull(x => component.SupplierId = x);
			Context.SaveChanges();
			BO.Components.TriggerUpdated(cmd, new Component(component));
			return new Component(component);
		}
	}
}

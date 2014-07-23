using SAMStock.DAL.Base;
using SAMStock.Database;
using Component = SAMStock.BO.Component;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentExecutor: BOCommandExecutor<CreateComponentCommand, Component>
	{
		public CreateComponentExecutor(IContext context) : base(context)
		{
		}

		public override Component Execute(CreateComponentCommand cmd)
		{
			var component = new Database.Component
			{
				Name = cmd.Name,
				ItemCode = cmd.ItemCode,
				MinimumStock = cmd.MinimumStock,
				Stock = cmd.MinimumStock,
				Price = cmd.Price,
				Remarks = cmd.Remarks,
				StockNumber = cmd.StockNumber,
				SupplierId = cmd.SupplierId
			};
			Context.Components.Add(component);
			Context.SaveChanges();
			var c = new Component(component);
			BO.Components.Manager.TriggerCreated(c);
			return c;
		}
	}
}
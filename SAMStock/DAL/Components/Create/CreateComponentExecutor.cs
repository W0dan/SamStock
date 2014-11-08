using SAMStock.Castle;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using Component = SAMStock.BO.Component;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentExecutor: RequestExecutor<CreateComponentRequest, CreateComponentResponse>
	{
		public CreateComponentExecutor(IContext context) : base(context)
		{
		}

		public override CreateComponentResponse Execute(CreateComponentRequest cmd)
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
			var r = new CreateComponentResponse(c);
			IoC.Instance.Resolve<BO.Components>().Create(c);
			return r;
		}
	}
}
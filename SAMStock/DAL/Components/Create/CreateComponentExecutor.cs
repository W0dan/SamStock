using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentExecutor: BOCommandExecutor<CreateComponentCommand, BO.Component>
	{
		public CreateComponentExecutor(IContext context) : base(context)
		{
		}

		public override BO.Component Execute(CreateComponentCommand cmd)
		{
			var component = new Component
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
			return new BO.Component(component);
		}
	}
}
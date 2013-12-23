using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.PedalComponent.FilterPedalComponent
{
	public class FilterPedalComponentRequestExecutor: IFilterPedalComponentRequestExecutor
	{
		private readonly IContext _context;

		public FilterPedalComponentRequestExecutor(IContext context)
		{
			_context = context;
		}

		public FilterPedalComponentResponse Execute(FilterPedalComponentRequest request)
		{
			decimal defaultmargin = _context.AdminData.Single().DefaultPedalPriceMargin;

			IEnumerable<Database.PedalComponent> pedalcomps = _context.PedalComponent;
			if (request.ComponentId.HasValue) pedalcomps = pedalcomps.Where(x => x.ComponentId == request.ComponentId.Value);
			if (request.PedalId.HasValue) pedalcomps = pedalcomps.Where(x => x.PedalId == request.PedalId.Value);
			return new FilterPedalComponentResponse
			{
				PedalComponents = pedalcomps.Select(x => new FilterPedalComponentResponseItem
				{
					Pedal = _context.Pedal.Where(y => y.Id == x.PedalId).Select(y => new FilterPedalComponentResponsePedal
					{
						Name = y.Name,
						Id = y.Id,
						Price = y.Price,
						Margin = y.Margin ?? defaultmargin,
						DefaultMargin = defaultmargin
					}).Single(),
					Component = _context.Component.Where(y => y.Id == x.PedalId).Select(y => new FilterPedalComponentResponseComponent
					{
						ItemCode = y.ItemCode,
						Stocknr = y.Stocknr,
						MinimumStock = y.MinimumStock,
						Price = y.Price,
						Remark = y.Remarks,
						Name = y.Name,
						Quantity = y.Stock,
						Id = y.Id
					}).Single(),
					Quantity = x.Number
				}).ToList()
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Pedal.FilterPedal
{
	public class FilterPedalQueryExecutor : IFilterPedalQueryExecutor
	{
		private IContext _context;

		public FilterPedalQueryExecutor(IContext context)
		{
			_context = context;
		}
		public FilterPedalResponse Execute(FilterPedalRequest request)
		{
			decimal defaultpedalpricemargin = _context.AdminData.Where(y => y.Name == "DefaultPedalPriceMargin").Single().Value;
			FilterPedalResponse response = new FilterPedalResponse();
			if (request.Id > 0)
			{
				/*  response.List.Add(_context.Pedal.Where(p => p.Id == request.Id).Select(p => new FilterPedalResponsePedal {
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Margin = (p.Margin != null) ? (decimal)p.Margin : defaultpedalpricemargin,
					List = _context.PedalComponent.Where(c => c.PedalId == p.Id).Select(c => new FilterPedalResponseComponent{
						Stocknr = c.Component.Stocknr,
						Description = c.Component.Name,
						Quantity = c.Number,
						Price = c.Component.Price,
						Stock = c.Component.Quantity,
						MinimumStock = c.Component.MinimumStock
					}).ToList()
				}).Single());    */

				response.List.Add(_context.Pedal.Where(p => p.Id == request.Id).Select(p => new FilterPedalResponsePedal
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Margin = (p.Margin != null) ? (decimal)p.Margin : defaultpedalpricemargin
				}).Single());

				List<PedalComponentDelegator> pedalcomps = _context.PedalComponent.Where(c => c.PedalId == request.Id).Select(c => new PedalComponentDelegator
				{
					Id = c.ComponentId,
					Quantity = c.Number
				}).ToList();

				for (int i = 0; i < pedalcomps.Count; i++)
				{
					int id = pedalcomps[i].Id;
					int count = pedalcomps[i].Quantity;
					response.List[0].List.Add(_context.Component.Where(c => c.Id == id).Select(c => new FilterPedalResponseComponent
					{
						Stocknr = c.Stocknr,
						Description = c.Name,
						Quantity = count,
						Price = c.Price,
						Stock = c.Stock,
					}).Single());
				}
			}
			else
			{
				/*  response.List.AddRange(_context.Pedal.Select(p => new FilterPedalResponsePedal {
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Margin = (p.Margin != null) ? (decimal)p.Margin : defaultpedalpricemargin,
					List = _context.PedalComponent.Where(c => c.PedalId == p.Id).Select(c => new FilterPedalResponseComponent{
						Stocknr = c.Component.Stocknr,
						Description = c.Component.Name,
						Quantity = c.Number,
						Price = c.Component.Price,
						Stock = c.Component.Quantity,
						MinimumStock = c.Component.MinimumStock
					}).ToList()
				}).ToList());   */

				response.List.AddRange(_context.Pedal.Select(p => new FilterPedalResponsePedal
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Margin = p.Margin == null ? defaultpedalpricemargin : (decimal)p.Margin
				}).ToList());

				for (int pedal = 0; pedal < response.List.Count; pedal++)
				{
					int pid = response.List[pedal].Id;
					List<PedalComponentDelegator> pedalcomps = _context.PedalComponent.Where(c => c.PedalId == pid).Select(c => new PedalComponentDelegator
					{
						Id = c.ComponentId,
						Quantity = c.Number
					}).ToList();

					for (int i = 0; i < pedalcomps.Count; i++)
					{
						int cid = pedalcomps[i].Id;
						int count = pedalcomps[i].Quantity;
						response.List[pedal].List.Add(_context.Component.Where(c => c.Id == cid).Select(c => new FilterPedalResponseComponent
						{
							Stocknr = c.Stocknr,
							Description = c.Name,
							Quantity = count,
							Price = c.Price
						}).Single());
					}
				}
			}
			return response;
		}
	}

	public class PedalComponentDelegator
	{
		public int Id;
		public int Quantity;
	}
}
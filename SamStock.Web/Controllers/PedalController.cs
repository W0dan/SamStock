using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamStock.Utilities;
using SamStock.Web.Models.Pedal;
using SamStock.Pedal.UpdatePedal;
using SamStock.Pedal.FilterPedal;
using SamStock.Stock.UpdateStock;
using SamStock.Pedal.AddPedal;
using SamStock.Pedal.UpdatePedalComponents;
using SamStock.Stock.FilterStock;
using SamStock.Admin.GetAdminData;

namespace SamStock.Web.Controllers
{
	public class PedalController : Controller
	{
		private readonly IDispatcher _dispatcher;

		public PedalController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		[HttpGet]
		public ViewResult Index()
		{
			var response = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest());
			var model = new PedalViewModel(response, _dispatcher.DispatchRequest<GetAdminDataRequest, GetAdminDataResponse>(new GetAdminDataRequest()));
			return View(model);
		}

		[HttpGet]
		public ViewResult Details(int id)
		{
			FilterPedalResponse response = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest(id));
			PedalViewModel view = new PedalViewModel(response, _dispatcher.DispatchRequest<GetAdminDataRequest, GetAdminDataResponse>(new GetAdminDataRequest()));
			view.List[0].List = view.List[0].List.OrderBy(c => c.Stocknr).ToList();
			return View(view);
		}

		[HttpGet]
		public ViewResult Update(int id)
		{
			var pedal = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest(id));
			PedalUpdateViewModel view = new PedalUpdateViewModel(pedal.List[0].Id, pedal.List[0].Name, pedal.List[0].Price, pedal.List[0].Margin);
			return View(view);
		}

		[HttpPost]
		public RedirectToRouteResult Update(PedalViewModelPedal viewmodel)
		{
			_dispatcher.DispatchCommand<UpdatePedalCommand>(new UpdatePedalCommand(viewmodel.Id, viewmodel.Name, viewmodel.Price, viewmodel.Margin));
			return RedirectToAction("Update", new { viewmodel.Id });
		}

		[HttpGet]
		public ViewResult UpdateComponents(int id)
		{
			var pedal = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest(id));
			return View(new PedalUpdateComponentsViewModel(pedal));
		}

		[HttpPost]
		public RedirectToRouteResult UpdateComponents(PedalUpdateComponentsInputViewModel viewmodel)
		{
			var stockitem = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(new FilterStockRequest(viewmodel.Stocknr, 0, false));
			if (stockitem.List.Count > 0)
			{
				_dispatcher.DispatchCommand<UpdatePedalComponentsCommand>(new UpdatePedalComponentsCommand(viewmodel.Id, stockitem.List[0].Id, viewmodel.Quanity));
			}
			return RedirectToAction("UpdateComponents", new { viewmodel.Id });
		}

		[HttpGet]
		public RedirectToRouteResult Build(int id)
		{
			var pedal = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest(id));
			List<StockUpdate> list = new List<StockUpdate>();
			foreach (FilterPedalResponseComponent comp in pedal.List[0].List)
			{
				list.Add(new StockUpdate(comp.Stocknr, comp.Quantity * -1, comp.Price));
			}
			UpdateStockCommand cmd = new UpdateStockCommand();
			cmd.List = list;
			_dispatcher.DispatchCommand<UpdateStockCommand>(cmd);
			return RedirectToAction("Details", new { id });
		}

		[HttpGet]
		public ViewResult Create()
		{
			return View();
		}

		[HttpPost]
		public RedirectToRouteResult Create(PedalViewModelPedal viewmodel)
		{
			_dispatcher.DispatchCommand<AddPedalCommand>(new AddPedalCommand(viewmodel.Name, viewmodel.Price, viewmodel.Margin));
			return RedirectToAction("Index");
		}
	}
}

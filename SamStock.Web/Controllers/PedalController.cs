using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAMStock.Utilities;
using SAMStock.Web.Models.Pedal;
using SAMStock.Pedal.UpdatePedal;
using SAMStock.Pedal.FilterPedal;
using SAMStock.Stock.UpdateStock;
using SAMStock.Pedal.AddPedal;
using SAMStock.Pedal.UpdatePedalComponents;
using SAMStock.Stock.FilterStock;
using SAMStock.Admin.GetAdminData;

namespace SAMStock.Web.Controllers
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
			view.Pedals[0].Components = view.Pedals[0].Components.OrderBy(c => c.Stocknr).ToList();
			return View(view);
		}

		[HttpGet]
		public ViewResult Update(int id)
		{
			var pedal = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest(id));
			PedalViewModelPedal view = new PedalViewModelPedal(pedal.Pedals[0].Id, pedal.Pedals[0].Name, pedal.Pedals[0].Price, pedal.Pedals[0].Margin);
			return View(view);
		}

		[HttpPost]
		public RedirectToRouteResult Update(PedalViewModelPedal viewmodel)
		{
			_dispatcher.DispatchCommand(new UpdatePedalCommand(viewmodel.Id, viewmodel.Name, viewmodel.Price, viewmodel.Margin));
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
			var stockitem = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(new FilterStockRequest(stockNr:viewmodel.Stocknr));
			if (stockitem.Components.Count > 0)
			{
				_dispatcher.DispatchCommand<UpdatePedalComponentsCommand>(new UpdatePedalComponentsCommand(viewmodel.Id, stockitem.Components[0].Id, viewmodel.Quantity));
			}
			return RedirectToAction("UpdateComponents", new { viewmodel.Id });
		}

		[HttpGet]
		public RedirectToRouteResult Build(int id)
		{
			var pedal = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest(id));
			List<StockUpdate> list = new List<StockUpdate>();
			foreach (FilterPedalResponseComponent comp in pedal.Pedals[0].Components)
			{
				list.Add(new StockUpdate(comp.Stocknr, comp.Quantity * -1, comp.Price));
			}
			UpdateStockCommand cmd = new UpdateStockCommand();
			cmd.StockUpdates = list;
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

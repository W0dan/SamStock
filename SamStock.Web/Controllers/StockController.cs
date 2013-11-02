using System.Collections.Generic;
using System.Web.Mvc;
using SAMStock.Stock.AddComponent;
using SAMStock.Stock.GetStockRefdata;
using SAMStock.Stock.UpdateStock;
using SAMStock.Stock.FilterStock;
using SAMStock.Utilities;
using SAMStock.Web.Models;
using SAMStock.Stock.ModifyStock;
using SAMStock.Web.Models.Stock;

namespace SAMStock.Web.Controllers
{
	public class StockController : Controller
	{
		private readonly IDispatcher _dispatcher;

		public StockController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		[HttpGet]
		public ViewResult Index()
		{
			var stockOverzicht = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(new FilterStockRequest());
			var refdata = GetRefdata();

			var model = new StockViewModel(stockOverzicht.Components, refdata);

			return View(model);
		}

		private GetStockRefdataResponse GetRefdata()
		{
			var refdata =
				_dispatcher.DispatchRequest<GetStockRefdataRequest, GetStockRefdataResponse>(new GetStockRefdataRequest());
			return refdata;
		}

		public ActionResult Search(StockFilterViewModel stockFilterViewModel)
		{
			var request = new FilterStockRequest(stockFilterViewModel.ComponentTypeFilter, stockFilterViewModel.SupplierFilter, stockFilterViewModel.MancoFilter);
			var filteredstock = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(request);

			var stockOverzicht = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(new FilterStockRequest());

			var model = new StockViewModel(filteredstock.Components, GetRefdata(), (new StockViewModel(stockOverzicht.Components, GetRefdata()))._contentTotalValue);

			return View("Index", model);
		}

		[HttpGet]
		public ViewResult AddComponent()
		{
			var response = _dispatcher.DispatchRequest<GetStockRefdataRequest,GetStockRefdataResponse>(new GetStockRefdataRequest());
			return View(new AddComponentViewModel(response));
		}
		
		[HttpPost]
		public RedirectToRouteResult AddComponent(StockViewModelNewItem newItem)
		{
			var command = new AddComponentCommand(newItem.Name,
				newItem.MinimumStock,
				newItem.Quantity,
				newItem.Stocknr,
				newItem.Price,
				newItem.SupplierId,
				newItem.Remarks,
				newItem.ItemCode);

			_dispatcher.DispatchCommand(command);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Update(StockChangesViewModel stockChanges)
		{
			var command = new UpdateStockCommand { StockUpdates = new List<StockUpdate>() };
			foreach (var stockChange in stockChanges.StockChanges)
			{
				command.StockUpdates.Add(new StockUpdate(stockChange.Stocknr, stockChange.Quantity, stockChange.Price));
			}
			_dispatcher.DispatchCommand(command);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ViewResult SearchByStocknr()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SearchByStocknr(string Stocknr)
		{
			var response = _dispatcher.DispatchRequest<FilterStockRequest,FilterStockResponse>(new FilterStockRequest(Stocknr,0,false));
			if (response.Components.Count > 0)
			{
				return RedirectToAction("ModifyComponent",response.Components[0]);
			} else
			{
				return RedirectToAction("SearchByStocknr");
			}
		}

		[HttpGet]
		public ViewResult ModifyComponent(FilterStockItem item)
		{
			return View(new StockModifyComponentViewModel(item));
		}

		[HttpPost]
		public ActionResult ModifyComponent(StockModifyComponentViewModel viewmodel)
		{
			_dispatcher.DispatchCommand<ModifyStockCommand>(new ModifyStockCommand(viewmodel.Id, viewmodel.Name, viewmodel.MinimumStock, viewmodel.Quantity, viewmodel.Stocknr, viewmodel.Price, viewmodel.SupplierName, viewmodel.Remarks, viewmodel.ItemCode, viewmodel.DeleteOption));
			return RedirectToAction("SearchByStocknr");
		}
	}
}
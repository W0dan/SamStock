using System.Collections.Generic;
using System.Web.Mvc;
using SamStock.Stock.ComponentToevoegen;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;
using SamStock.Stock.UpdateStock;
using SamStock.Stock.FilterStock;
using SamStock.Utilities;
using SamStock.Web.Models;
using SamStock.Stock.FilterStock;

namespace SamStock.Web.Controllers
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
            var stockOverzicht = _dispatcher.DispatchRequest<GetStockOverzichtRequest, GetStockOverzichtResponse>(new GetStockOverzichtRequest());
            var refdata = GetRefdata();

            var model = new StockViewModel(stockOverzicht.List, refdata);

            return View(model);
        }

        private GetStockRefdataResponse GetRefdata()
        {
            var refdata =
                _dispatcher.DispatchRequest<GetStockRefdataRequest, GetStockRefdataResponse>(new GetStockRefdataRequest());
            return refdata;
        }

        public ActionResult FindMancos() {
            var request = new FilterStockRequest("",0,true);
            var mancos = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(request);

            var model = new StockViewModel(mancos.List, GetRefdata());

            return View("Index", model);
        }

        public ActionResult Search(StockFilterViewModel stockFilterViewModel)
        {
            var request = new FilterStockRequest(stockFilterViewModel.ComponentTypeFilter, stockFilterViewModel.LeverancierFilter);
            var filteredstock = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(request);

            var model = new StockViewModel(filteredstock.List, GetRefdata());

            return View("Index", model);
        }

        [HttpPost]
        public RedirectToRouteResult ComponentToevoegen(StockViewModelNewItem newItem)
        {
            var command = new ComponentToevoegenCommand(newItem.Naam,
                newItem.MinimumStock,
                newItem.Hoeveelheid,
                newItem.Stocknr,
                newItem.Prijs,
                newItem.LeverancierId,
                newItem.Opmerkingen);

            _dispatcher.DispatchCommand(command);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(StockChangesViewModel stockChanges)
        {
            var command = new UpdateStockCommand { List = new List<StockUpdate>() };
            foreach (var stockChange in stockChanges.List)
            {
                command.List.Add(new StockUpdate(stockChange.Stocknr, stockChange.Amount, stockChange.Prijs));
            }
            _dispatcher.DispatchCommand(command);
            return RedirectToAction("Index");
        }
    }
}
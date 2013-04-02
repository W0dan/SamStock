using System.Web.Mvc;
using SamStock.Database;
using SamStock.Stock.ComponentToevoegen;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;
using SamStock.Utilities;
using SamStock.Web.Models;

namespace SamStock.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly IDispatcher _dispatcher;
        private readonly ComponentToevoegenHandler _componentToevoegenHandler;

        public StockController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            var context = new StockBeheerEntities();

            var componentToevoegenCommandExecutor = new ComponentToevoegenCommandExecutor(context);
            _componentToevoegenHandler = new ComponentToevoegenHandler(componentToevoegenCommandExecutor);
        }

        [HttpGet]
        public ViewResult Index()
        {
            var stockOverzicht = _dispatcher.DispatchQuery<GetStockOverzichtRequest, GetStockOverzichtResponse>(new GetStockOverzichtRequest());
            var refdata = _dispatcher.DispatchQuery<GetStockRefdataRequest, GetStockRefdataResponse>(new GetStockRefdataRequest());

            var model = new StockViewModel(stockOverzicht.List, refdata);

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult ComponentToevoegen(StockViewModel model)
        {
            var newItem = model.NewItem;

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
    }
}
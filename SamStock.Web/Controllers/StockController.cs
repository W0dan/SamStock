using System.Web.Mvc;
using SamStock.Database;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;
using SamStock.Web.Models;

namespace SamStock.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly GetStockOverzichtHandler _getStockOverzichtHandler;
        private readonly GetStockRefdataHandler _getStockRefdataHandler;

        public StockController()
        {
            var context = new StockBeheerEntities();
            var getStockOverzichtQueryExecutor = new GetStockOverzichtQueryExecutor(context);
            _getStockOverzichtHandler = new GetStockOverzichtHandler(getStockOverzichtQueryExecutor);

            var getStockRefdataQueryExecutor = new GetStockRefdataQueryExecutor(context);
            _getStockRefdataHandler = new GetStockRefdataHandler(getStockRefdataQueryExecutor);
        }

        [HttpGet]
        public ViewResult Index()
        {
            var stockOverzicht = _getStockOverzichtHandler.Handle(new GetStockOverzichtQuery());
            var refdata = _getStockRefdataHandler.Handle(new GetStockRefdataRequest());

            var model = new StockViewModel(stockOverzicht.List, refdata);

            return View(model);
        }
    }
}
﻿using System.Web.Mvc;
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

        public ActionResult Search(StockFilterViewModel stockFilterViewModel)
        {
            return null;
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
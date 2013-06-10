using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamStock.Utilities;
using SamStock.Web.Models;
using SamStock.Pedal.UpdatePedal;
using SamStock.Pedal.FilterPedal;
using SamStock.Stock.UpdateStock;
using SamStock.Pedal.AddPedal;
using SamStock.Pedal.UpdatePedalComponents;
using SamStock.Stock.FilterStock;

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
            List<FilterPedalResponsePedal> list = _dispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest()).List;
            var model = new PedalViewModel(list);
            return View(model);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            var result = _dispatcher.DispatchRequest<FilterPedalRequest,FilterPedalResponse>(new FilterPedalRequest(id)).List[0];
            PedalViewModel view = new PedalViewModel(result);
            view.List[0].List = view.List[0].List.OrderBy(c => c.Stocknr).ToList();
            return View(view);
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            var pedal = _dispatcher.DispatchRequest<FilterPedalRequest,FilterPedalResponse>(new FilterPedalRequest(id));
            PedalUpdateViewModel view = new PedalUpdateViewModel(pedal.List[0].Id,pedal.List[0].Name,pedal.List[0].Price,pedal.List[0].Margin);
            return View(view);   
        }

        [HttpPost]
        public RedirectToRouteResult Update(int id, String name, decimal price, decimal margin)
        {
            _dispatcher.DispatchCommand<UpdatePedalCommand>(new UpdatePedalCommand(id, name, price, margin));
            return RedirectToAction("Update",new {id});
        }

        [HttpGet]
        public ViewResult UpdateComponents(int id)
        {
            var pedal = _dispatcher.DispatchRequest<FilterPedalRequest,FilterPedalResponse>(new FilterPedalRequest(id));
            // var stock = _dispatcher.DispatchRequest<FilterStockRequest,FilterStockResponse>(new FilterStockRequest()).List;
            PedalUpdateComponentsViewModel view = new PedalUpdateComponentsViewModel(id,pedal.List[0].List/*,stock*/);
            return View(view);
        }

        [HttpPost]
        public RedirectToRouteResult UpdateComponents(int id, String stocknr, int quantity)
        {
            var stockitem = _dispatcher.DispatchRequest<FilterStockRequest,FilterStockResponse>(new FilterStockRequest(stocknr,0,false));
            if (stockitem.List.Count > 0)
            {
                _dispatcher.DispatchCommand<UpdatePedalComponentsCommand>(new UpdatePedalComponentsCommand(id, stockitem.List[0].Id, quantity));
            }
            return RedirectToAction("UpdateComponents",new {id});
        }

        [HttpGet]
        public RedirectToRouteResult Build(int id)
        {
            var pedal = _dispatcher.DispatchRequest<FilterPedalRequest,FilterPedalResponse>(new FilterPedalRequest(id));
            List<StockUpdate> list = new List<StockUpdate>();
            foreach (FilterPedalResponseComponent comp in pedal.List[0].List)
            {
                list.Add(new StockUpdate(comp.Stocknr,comp.Count*-1,comp.Price));
            }
            UpdateStockCommand cmd = new UpdateStockCommand();
            cmd.List = list;
            _dispatcher.DispatchCommand<UpdateStockCommand>(cmd);
            return RedirectToAction("Details",new { id });
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Create(String name, decimal price, decimal margin)
        {
            _dispatcher.DispatchCommand<AddPedalCommand>(new AddPedalCommand(name, price, margin));
            return RedirectToAction("Index");
        }
    }
}

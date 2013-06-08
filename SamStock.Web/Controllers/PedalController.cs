using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamStock.Utilities;
using SamStock.Web.Models;
using SamStock.Pedal.UpdatePedal;
using SamStock.Pedal.FilterPedal;

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
        public ViewResult Edit(int id)
        {
            return View();   
        }

        [HttpPost]
        public ActionResult Update(String name, int id, decimal price, decimal margin, String componentStocknr, int componentCount)
        {
            // _dispatcher.DispatchCommand<UpdatePedalCommand>(new UpdatePedalCommand(id,name,price,margin,componentStocknr,componentCount));
            return RedirectToAction("Edit",id);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
    }
}

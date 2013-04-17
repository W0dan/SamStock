using System.Collections.Generic;
using System.Web.Mvc;
using SamStock.Beheer.Leveranciers.GetLeveranciers;
using SamStock.Utilities;
using SamStock.Web.Models;

namespace SamStock.Web.Controllers
{
    public class BeheerController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public BeheerController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public ViewResult Leveranciers()
        {
            var result = _dispatcher.DispatchRequest<GetLeveranciersRequest, GetLeveranciersResponse>(new GetLeveranciersRequest());

            var viewmodel = new LeveranciersViewModel(result);

            return View(viewmodel);
        }

        public ActionResult LeverancierToevoegen()
        {
            return null;
        }
    }
}
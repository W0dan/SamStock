using System.Web.Mvc;
using SamStock.Beheer.Leveranciers.AddLeverancier;
using SamStock.Beheer.Leveranciers.GetLeveranciers;
using SamStock.Utilities;
using SamStock.Web.Models;

namespace SamStock.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public AdminController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Suppliers()
        {
            var result = _dispatcher.DispatchRequest<GetLeveranciersRequest, GetLeveranciersResponse>(new GetLeveranciersRequest());

            var viewmodel = new LeveranciersViewModel(result);

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddLeverancier(LeverancierViewModelNewItem viewModel)
        {
            _dispatcher.DispatchCommand(new AddLeverancierCommand(viewModel.Name, viewModel.Address, viewModel.Website));
            return RedirectToAction("Suppliers");
        }
    }
}
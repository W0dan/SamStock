using System.Web.Mvc;
using SamStock.Supplier.AddSupplier;
using SamStock.Supplier.GetSuppliers;
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
            var result = _dispatcher.DispatchRequest<GetSuppliersRequest, GetSuppliersResponse>(new GetSuppliersRequest());

            var viewmodel = new SuppliersViewModel(result);

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Config(int VAT)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddLeverancier(SupplierViewModelNewItem viewModel)
        {
            _dispatcher.DispatchCommand(new AddSupplierCommand(viewModel.Name, viewModel.Address, viewModel.Website));
            return RedirectToAction("Suppliers");
        }
    }
}
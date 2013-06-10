using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamStock.Web.Models;
using SamStock.Utilities;
using SamStock.Supplier.GetSuppliers;

namespace SamStock.Web.Controllers
{
    public class SupplierController : Controller
    {
        private IDispatcher _dispatcher;

        public SupplierController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var response = _dispatcher.DispatchRequest<GetSuppliersRequest,GetSuppliersResponse>(new GetSuppliersRequest());
            return View(new SuppliersViewModel(response));
        }

    }
}

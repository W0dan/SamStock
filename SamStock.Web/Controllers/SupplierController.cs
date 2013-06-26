using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamStock.Web.Models.Supplier;
using SamStock.Utilities;
using SamStock.Supplier.GetSuppliers;
using SamStock.Supplier.AddSupplier;

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
			var response = _dispatcher.DispatchRequest<GetSuppliersRequest, GetSuppliersResponse>(new GetSuppliersRequest());
			return View(new SuppliersViewModel(response));
		}

		[HttpPost]
		public ActionResult AddSupplier(SupplierViewModelNewItem viewModel)
		{
			_dispatcher.DispatchCommand(new AddSupplierCommand(viewModel.Name, viewModel.Address, viewModel.Website));
			return RedirectToAction("Index");
		}
	}
}

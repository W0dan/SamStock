using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SAMStock.Admin.GetAdminData;
using SAMStock.Admin.SetAdminData;
using SAMStock.Utilities;
using SAMStock.Web.Models.Admin;

namespace SAMStock.Web.Controllers
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
			var response = _dispatcher.DispatchRequest<GetAdminDataRequest, GetAdminDataResponse>(new GetAdminDataRequest());
			return View(new AdminViewModel(response));
		}

		[HttpPost]
		public ActionResult SetConfig(AdminViewModel viewmodel)
		{
			var cmd = new SetAdminDataCommand(viewmodel.VAT, viewmodel.DefaultPedalPriceMargin);
			_dispatcher.DispatchCommand<SetAdminDataCommand>(cmd);
			return RedirectToAction("Index");
		}
	}
}
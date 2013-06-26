using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SamStock.Admin.GetAdminData;
using SamStock.Admin.SetAdminData;
using SamStock.Utilities;
using SamStock.Web.Models.Admin;

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
			var response = _dispatcher.DispatchRequest<GetAdminDataRequest, GetAdminDataResponse>(new GetAdminDataRequest());
			return View(new AdminViewModel(response));
		}

		[HttpPost]
		public ActionResult SetConfig(AdminViewModel viewmodel)
		{
			var cmd = new SetAdminDataCommand(new Dictionary<String, Decimal>{
                {"VAT",viewmodel.VAT},
                {"DefaultPedalPriceMargin",viewmodel.DefaultPedalPriceMargin}
            });
			_dispatcher.DispatchCommand<SetAdminDataCommand>(cmd);
			return RedirectToAction("Index");
		}
	}
}
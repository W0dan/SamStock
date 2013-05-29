using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamStock.Web.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

    }
}

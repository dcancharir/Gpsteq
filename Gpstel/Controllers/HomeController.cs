using Gpstel.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Security;
//using Gpstel.Filters;

namespace Gpstel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[Autenticado]
        [CustomAuthorize(Roles = "admin,employee")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
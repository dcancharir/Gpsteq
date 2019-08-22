using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Security;
using Gpstel.Models;

namespace Gpstel.Controllers
{
    public class DemoController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Work1()
        {
            return View("Work1");
        }
        [CustomAuthorize(Roles = "admin,employee")]
        public ActionResult Work2()
        {
            return View("Work2");
        }
    }
}
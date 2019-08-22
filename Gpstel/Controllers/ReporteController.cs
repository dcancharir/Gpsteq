using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using Gpstel.Security;

namespace Gpstel.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        ModelGps context = null;
        [CustomAuthorize(Roles = "admin,employee")]
        public ActionResult Index()
        {
            context = new ModelGps();
            return View(context.Vehiculo.ToList());
        }
        public ActionResult Detalle(int id) {
            context = new ModelGps();
            ViewBag.idVehiculo = id;
            return PartialView(context.Pago.Where(x=>x.idvehiculo==id).OrderByDescending(x=>x.fecha_pago).ToList());
        }
        [CustomAuthorize(Roles = "admin,employee")]
        public ActionResult Index2(string operador) {
            context = new ModelGps();
            if (operador == null)
            {
                ViewBag.operadorreporte = operador;
                return View(context.CHIP.ToList());
            }
            else
            {
                //context = new ModelGps();
                ViewBag.operadorreporte = operador;
                return View(context.CHIP.Where(x => x.operador == operador).ToList());
            }

            
        }
        [CustomAuthorize(Roles = "admin,employee")]
        public ActionResult Index3() {
           
            
            return View();
        }
        //public ActionResult Chip(string operador) {
            
        //}
    }
}
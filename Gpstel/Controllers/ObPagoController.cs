using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using Gpstel.Security;

namespace Gpstel.Controllers
{
    public class ObPagoController : Controller
    {
        private ObservacionPago observacionPago = new ObservacionPago();
        // GET: ObPago
        [CustomAuthorize(Roles = "admin,epmloyee")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult observacion(int id = 0)
        {
            if (id == 0)
            {
                return Redirect("~/Pago");
            }
            else
            {
                var nPago = new List<ObservacionPago>();
                nPago = observacionPago.listarObservaciones(id);
                ViewBag.idPago = id;

                return View(nPago);
            }

        }

        public ActionResult guardarEditar(ObservacionPago ob)
        {

            string mensaje = "";
            var v = new ObservacionPago();

            try
            {
                mensaje = ob.guardarEditar();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("observacion", "ObPago", new { @id = ob.idpago });


        }
    }
}
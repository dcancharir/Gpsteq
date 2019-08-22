using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using Gpstel.Security;

namespace Gpstel.Controllers
{
    public class ObVehiculoController : Controller
    {
        private ObservacionVehiculo observacionVehiculo = new ObservacionVehiculo();

        // GET: ObCliente
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult observacion(int id = 0)
        {
            if (id == 0)
            {
                return Redirect("~/Vehiculo");
            }
            else
            {
                var nVehiculo = new List<ObservacionVehiculo>();
                nVehiculo = observacionVehiculo.listarObservaciones(id);
                ViewBag.idVehiculo = id;

                return View(nVehiculo);
            }

        }

        public ActionResult guardarEditar(ObservacionVehiculo ob)
        {

            string mensaje = "";
            var v = new ObservacionVehiculo();

            try
            {
                mensaje = ob.guardarEditar();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("observacion", "obVehiculo", new { @id = ob.idvehiculo });


        }
    }
}
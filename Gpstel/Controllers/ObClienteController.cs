using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using Gpstel.Security;

namespace Gpstel.Controllers
{
    public class ObClienteController : Controller
    {
        private ObservacionCliente observacionCliente = new ObservacionCliente();

        // GET: ObCliente
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult observacion( int id =0)
        {
            if (id ==0)
            {
                return Redirect("~/Cliente");
            }
            else
            {
                var nCliente = new List<ObservacionCliente>();
                nCliente = observacionCliente.listarObservaciones(id);
                ViewBag.idCliente = id;

                return View(nCliente);
            }
         
        }
        
        public ActionResult guardarEditar(ObservacionCliente ob) {

            string mensaje = "";
            var v = new ObservacionCliente();

            try
            {
                mensaje = ob.guardarEditar();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("observacion", "ObCliente", new { @id = ob.idcliente });
            
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Gpstel.Models;
using Gpstel.Security;

namespace Gpstel.Controllers
{
    public class ChipController : Controller
    {
        private BaseRespuesta resultado = new BaseRespuesta();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        private CHIP objChip = new CHIP();

        // GET: Chip
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {


            return View(objChip.listarchip());
        }
        [HttpPost]
        public ActionResult guardarEditar(CHIP chip) {

            var resultado = new BaseRespuesta();

            try
            {
                chip.guardarEditar();

                resultado.mensaje = "Exito en el Proceso";
                resultado.ok = "tru";
            }
            catch (Exception e)
            {
                resultado.mensaje = e.Message;
                resultado.ok = "false";

            }

            return Json(resultado);

        }
        [HttpPost]
        public JsonResult getChip(int id)
        {
            var chip = new CHIP();
            chip = objChip.obtenerChip(id);
            chip.GPS=null;

            return Json(chip);
        }

        
        public ActionResult eliminarChip(int id) {

            try
            {
                objChip.idchip = id;
                objChip.eliminarChip();
            }
            catch (Exception)
            {

                return Redirect("~/Chip");
            }



            return Redirect("~/Chip");
        }
    }
}
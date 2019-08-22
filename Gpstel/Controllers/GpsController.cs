using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Gpstel.Models;
using Gpstel.Security;

namespace Gpstel.Controllers
{
    public class GpsController : Controller
    {

        private GPS objGps = new GPS();
        private CHIP objChip = new CHIP();
        private jsonChip jsonChip= new jsonChip();
        private jsonGps jsonGps = new jsonGps();
        private jsonModel JsonModel = new jsonModel();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        private BaseRespuesta resultado = new BaseRespuesta();

        // GET: Gps
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            var noRepetido = objChip.obtenerChipnoRepetido();

            ViewBag.chiNorepetido = noRepetido;

            return View(objGps.listarGps());
        }

        [HttpPost]
        public JsonResult getGps(int id) {
            var gps = new GPS();
            var dataGps = new jsonModel();
            var chipJson = new jsonChip();
            var gpsJson = new jsonGps();
          

            gps = objGps.obtenerGps(id);
          

            gpsJson.idGps =Convert.ToString( gps.idgps);
            gpsJson.idChip =Convert.ToString( gps.idchip);
            gpsJson.modelo = gps.modelo;
            gpsJson.estadoUso = gps.estado_uso;
            gpsJson.garantia = gps.garantia;
            gpsJson.fechaCompra = parseDate( Convert.ToString(gps.fecha_compra));
            gpsJson.imei = gps.imei;

            chipJson.numero =gps.CHIP.numero;

            dataGps.jsonGps = gpsJson;
            dataGps.jsonchip = chipJson;

            return Json(dataGps);
        }

        public static string parseDate(string dataTime) {

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString(dataTime);
            return sqlFormattedDate;
        }

        [HttpPost]
        public ActionResult guardarEditar(GPS gps) {

            var resultado = new BaseRespuesta();
            
            try
            {
                gps.guardarEditar();
                resultado.mensaje="Exito en el Proceso";
                resultado.ok = "true";
            }
            catch (Exception e)
            {

                resultado.mensaje = e.Message;
                resultado.ok = "false";
            }

            return Json(resultado);
        }

        public ActionResult eliminarGps(int id)
        {
            try
            {
                objGps.idgps = id;
                objGps.eliminarGps();

            }
            catch (Exception)
            {

                return Redirect("~/Gps");
            }



            return Redirect("~/Gps");
        }
    }
}
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
    public class PagoController : Controller
    {
        private Pago pago = new Pago();
        private Vehiculo vehiculos = new Vehiculo();
        // GET: Pago
        [CustomAuthorize(Roles = "admin,employee")]
        public ActionResult Index()
        {         
                return View(vehiculos.listarVehiculo());      

        }
        public ActionResult Ver(int id)
        {
            return View(vehiculos.obtenerVehiculoxId(id));
        }
        [HttpPost]
        public JsonResult GetPago(int id)
        {
            //var mipago = new Pago();
            //var mipagoJson = new jsonPago();
            //var dataPago = new jsonModel();
            //mipago = pago.obtenerPago(id);
            //mipagoJson.idPago = Convert.ToString(mipago.idpago);
            //mipagoJson.idVehiculo = Convert.ToString(mipago.idvehiculo);
            //mipagoJson.estado = mipago.estado;
            //mipagoJson.monto =Convert.ToString( mipago.monto);
            //mipagoJson.concepto = mipago.concepto;
            //mipagoJson.fecha_pago = Convert.ToString(mipago.fecha_pago);
            //dataPago.jsonPago = mipagoJson;
            //mipago.Vehiculo = null;
            //pago.ObservacionPago = null;
            //ViewBag.pagoprueba = mipago;
            //ViewBag.dataPago = dataPago;

            return Json(pago.obtenerPago(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.iddepago = id;
            return View(
                id == 0 ? new Pago()/**para agregar un nuevo registro*/: pago.obtenerPago(id)/*Devolver el id del objeto*/
                );

        }
        public ActionResult GuardarPago(Pago editado)
        {
            if (ModelState.IsValid)
            {
                editado.guardar();
                // alt+126 para el simbolo de ñ
                return Redirect("~/Pago");
            }
            else
            {
                return View("~/Views/Pago/AgregarEditar.cshtml", editado);
            }
        }

        public ActionResult Guardar(Pago pago)
        {
            var resultado = new BaseRespuesta();
            if (ModelState.IsValid)
            {
                if (pago.idpago > 0)
                {
                    pago.idvehiculo = Convert.ToInt32(Request.Form.Get("idvehiculo"));
                    pago.concepto = Request.Form.Get("concepto");
                    pago.monto = Convert.ToDecimal(Request.Form.Get("monto"));
                    pago.fecha_pago = DateTime.Now;
                    pago.estado = "A";
                    pago.guardar();
                    resultado.mensaje = "Exito en el Proceso";
                    resultado.ok = "tru";
                    // alt+126 para el simbolo de ñ
                    return Redirect("~/Pago/Ver/" + pago.idvehiculo);
                }
                else {
                    pago.guardar();
                    resultado.mensaje = "Exito en el Proceso";
                    resultado.ok = "tru";
                    return Redirect("~/Pago/Ver/" + pago.idvehiculo);
                }
            }
            else
            {
                return View("~/Views/Pago/Ver.cshtml", pago);
            }
        }
    }
}
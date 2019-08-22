using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using System.Web.Script.Serialization;
using Gpstel.Security;

namespace Gpstel.Controllers
{

    
    public class VehiculoController : Controller
    {
        private jsonGps jsonGps = new jsonGps();
        private jsonCliente jsonCliente = new jsonCliente();
        private jsonModel JsonModel = new jsonModel();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        private BaseRespuesta resultado = new BaseRespuesta();
        private GPS objGps = new GPS();
        // GET: Vehiculo
        private Cliente objCliente = new Cliente();
       
        private Vehiculo objVehiculo = new Vehiculo();
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()

        {
            var noRepetido = objGps.obtenerGpsNoRepetido();

            ViewBag.gpsNorepetido = noRepetido;
            ViewBag.listacliente=objCliente.listarCliente();

            return View(objVehiculo.listarVehiculo());
            //return View(objVehiculo.listarVehiculo());
        }

        [HttpPost]
        public JsonResult getVehiculo(int id)
        {
            var vehiculo = new Vehiculo();
            var dataVehiculo = new jsonModel();
            var clienteJson = new jsonCliente();
            var gpsJson = new jsonGps();
            var vehiculoJson = new jsonVehiculo();


            vehiculo = objVehiculo.obtenerVehiculoxId(id);


            vehiculoJson.idVehiculo = Convert.ToString(vehiculo.idvehiculo);
            vehiculoJson.idGps = Convert.ToString(vehiculo.idgps);
            vehiculoJson.idCliente = Convert.ToString(vehiculo.idcliente);
            vehiculoJson.modelo = vehiculo.modelo;
            vehiculoJson.placa = vehiculo.placa;
            vehiculoJson.marca = vehiculo.marca;
            vehiculoJson.mensualidad = Convert.ToString(vehiculo.mensualidad);
            vehiculoJson.anio_vehiculo = vehiculo.anio_vehiculo;
            vehiculoJson.color = vehiculo.color;
            vehiculoJson.nro_motor = vehiculo.nro_motor;
            vehiculoJson.particular_mtc = vehiculo.particular_mtc;

            vehiculoJson.fecha_instalacion = parseDate(Convert.ToString(vehiculo.fecha_instalacion));
            

            gpsJson.imei = vehiculo.GPS.imei;
            gpsJson.modelo = vehiculo.GPS.modelo;
            dataVehiculo.jsonVehiculo = vehiculoJson;
            dataVehiculo.jsonGps = gpsJson;
            dataVehiculo.jsonCliente = clienteJson;

            return Json(dataVehiculo);
        }
        public static string parseDate(string dataTime)
        {

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString(dataTime);
            return sqlFormattedDate;
        }
        
        public ActionResult guardarEditar(Vehiculo vehiculo)
        {

            var resultado = new BaseRespuesta();

            try
            {
                vehiculo.guardarEditar();
                resultado.mensaje = "Exito en el Proceso";
                resultado.ok = "true";
            }
            catch (Exception e)
            {

                resultado.mensaje = e.Message;
                resultado.ok = "false";
            }

            return Json(resultado);
        }
        public ActionResult eliminarVehiculo(int id)
        {
            try
            {
                objVehiculo.idvehiculo = id;
                objVehiculo.eliminarVehiculo();

            }
            catch (Exception)
            {

                return Redirect("~/Vehiculo");
            }



            return Redirect("~/Vehiculo");
        }

        //public ActionResult nuevo(int id = 0) {
        //    var vehiculo = new Vehiculo();
        //    var gps = new List<GPS>();

        //    if (id == 0)
        //    {

        //        ViewBag.cliente = objCliente.listarCliente();
        //        ViewBag.gps = objGps.obtenerGpsNoRepetido();

        //        return View(vehiculo);
        //    }
        //    else
        //    {

        //        ViewBag.cliente = objCliente.listarCliente();

        //        ViewBag.gps = objGps.obtenerGpsNoRepetido();
        //        return View(vehiculo.obtenerVehiculoxId(id));
        //    }

        //}
    }
}
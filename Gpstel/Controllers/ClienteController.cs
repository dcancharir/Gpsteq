using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using System.Net.Mail;
using System.Net;
using Gpstel.Security;
//using Gpstel.Filters;

namespace Gpstel.Controllers
{
    public class ClienteController : Controller
    {
        private Cliente objCliente = new Cliente();
        private Distrito objDistrito = new Distrito();
        private Provincia objProvincia = new Provincia();
        private Departamento objDepartamento = new Departamento();
        private jsonProvincia jsonProvincia = new jsonProvincia();
        private jsonDistrito jsonDistrito = new jsonDistrito();
        private ModelGps mdl = new ModelGps();
        private ObservacionCliente observacionCliente = new ObservacionCliente();
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            var lista = objCliente.listarCliente();
            ViewBag.departamento = objDepartamento.listarDepartamento();
            return View(objCliente.listarCliente());
        }

        public JsonResult cargarProvincias(int iddepartamento) {
            var provincias = new List<jsonProvincia>();
            provincias = mdl.Database.SqlQuery<jsonProvincia>("Select * from Provincia where iddepartamento=@id", new SqlParameter("@id", iddepartamento))
                   .ToList();

            return Json(provincias);
        }

        public JsonResult cargarDitritos(int idprovincia)
        {
            var distritos = new List<jsonDistrito>();
            distritos = mdl.Database.SqlQuery<jsonDistrito>("Select * from Distrito where idprovincia=@id", new SqlParameter("@id", idprovincia))
                   .ToList();

            return Json(distritos);
        }

        [HttpPost]
        public ActionResult guardarEditar(Cliente cliente)
        {

            var resultado = new BaseRespuesta();

            try
            {
                cliente.guardarEditar();
                resultado.mensaje = "Exito en el Proceso";
                resultado.ok = "true";

                // ay esta aqui XD
                // Codigo feo :p jajaja
                ////    XD
                // Los nombres de los metodos deben de comenzar por mayuscula :p
                // un pata de un tuto me enseño asi el de enex u
                // ahhh, pero ahi te dice vs que debe de empezar por mayuscula
                


            }
            catch (Exception e)
            {

                resultado.mensaje = e.Message;
                resultado.ok = "false";
            }

            return Json(resultado);
        }


        [HttpPost]
        public JsonResult getCliente(int id) {

            var cliente = new Cliente();
            var dataCliente = new jsonClienteDistrito();
            var clienteJson = new jsonCliente();
            var distritoJson = new jsonDistrito();


            cliente = objCliente.obtenerCliente(id);

            clienteJson.idCliente = Convert.ToString(cliente.idcliente);
            clienteJson.fecha_contrato = parseDate(Convert.ToString(cliente.fecha_contrato));
            clienteJson.estado = cliente.estado;
            clienteJson.nombre = cliente.nombre;
            clienteJson.apellido = cliente.apellido;
            clienteJson.dni_ruc = cliente.dni_ruc;
            clienteJson.telefono = cliente.telefono;
            clienteJson.celular = cliente.celular;
            clienteJson.correo = cliente.correo;
            clienteJson.direccion = cliente.direccion;
            clienteJson.iddistrito =Convert.ToString( cliente.iddistrito);

            distritoJson.iddistrito = Convert.ToInt32(cliente.iddistrito);
            distritoJson.nombre = cliente.Distrito.nombre;
            distritoJson.idprovincia = Convert.ToInt32( cliente.Distrito.idprovincia);

            dataCliente.jsoncliente = clienteJson;
            dataCliente.jsondistrito = distritoJson;


            return Json(dataCliente);
        }
        public static string parseDate(string dataTime)
        {

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString(dataTime);
            return sqlFormattedDate;
        }

        public ActionResult eliminarCliente(int id) {

            try
            {
                objCliente.idcliente = id;
                objCliente.eliminarCliente();
            }
            catch (Exception)
            {

                return Redirect("~/Cliente");
            }
            return Redirect("~/Cliente");
        }
        //GET: Email
        public ActionResult Form(int id)
        {
            Cliente cliente = new Cliente();
            return View(cliente.obtenerCliente(id));
        }
        //[HttpPost]
        public ActionResult Envio()
        {          
           
                string receiverEmail = Request.Form.Get("receiverEmail").ToString();
                string subject = Request.Form.Get("subject");
                string message = Request.Form.Get("message");
                try
                {
                    if (ModelState.IsValid)
                    {
                        var senderemail = new MailAddress("d.cancharir@gmail.com", "GPSTEL");
                        var receiveremail = new MailAddress(receiverEmail, "Receiver");

                        var password = "niniabelia";
                        var sub = subject;
                        var body = message;
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(senderemail.Address, password)
                        };
                        using (var mess = new MailMessage(senderemail, receiveremail)
                        {
                            Subject = sub,
                            Body = body
                        })
                        {
                            smtp.Send(mess);
                        }
                        return Redirect("~/Cliente");
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "There are some problem in sending Email";
                }
                return Redirect("~/Cliente");
             
            
        
           
        
            
        }



    }
}
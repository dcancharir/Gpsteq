using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gpstel.Models;
using Gpstel.Security;
using Gpstel.ViewModels;

namespace Gpstel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Usuario
        Usuario miusuario = new Usuario();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UsuarioViewModel avm)
        {
            Usuario am = new Usuario();
            if (string.IsNullOrEmpty(avm.Usuario.nombre) || string.IsNullOrEmpty
                (avm.Usuario.password) || am.login(avm.Usuario.nombre, avm.Usuario.password) == null)
            {
                ViewBag.Error = "Accoun's Invalid";
                return View("Index");
            }
            var busqueda = miusuario.find(avm.Usuario.nombre);
            SessionPersister.Username = avm.Usuario.nombre;
            SessionPersister.Usertype = busqueda.tipo;
            //SessionPersister.Usertype = avm.Usuario.tipo.ToString();
            return Redirect("~/Home/Index");
        }
        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }
    }
}
namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    //instanciamos algunas bibliotecas mas deben de ir en las demas clases tambien menos en la Clase Evento
    using System.Linq;
    using System.Data.Entity;
    //Bibliotecas para trabajar con la foto de perfil
    using System.Web;
    using System.Data.Entity.Validation;
    using System.IO;
    using Gpstel.Security;
    

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int idusuario { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(18)]
        public string tipo { get; set; }
        public Usuario find(string username)
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new ModelGps())
                {
                    usuario=db.Usuario.Where(acc => acc.nombre.Equals(username)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }
        public Usuario login(string username, string password)
        {
            password = Encrypt.MD5(password);
            var usuario = new Usuario();
            try {
                using (var db = new ModelGps())
                {
                    usuario = db.Usuario.Where(acc => acc.nombre.Equals(username) &&
              acc.password.Equals(password)).FirstOrDefault();
                }
            } catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }
        public Usuario ObtenerxId(int id)
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new ModelGps())
                {
                    usuario = db.Usuario.Where(x => x.idusuario == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }
        //public ResponseModel ValidarLogin(string Usuario, string Password)
        //{
        //    var rm = new ResponseModel();
        //    try
        //    {
        //        using (var db = new ModelGps())
        //        {
        //            Password = HashHelper.MD5(Password);

        //            var usuario = db.Usuario.Where(x => x.nombre == Usuario).Where(x => x.password == Password).SingleOrDefault();
        //            if (usuario != null)
        //            {
        //                SessionHelper.AddUserToSession(usuario.idusuario.ToString());
        //                rm.SetResponse(true);
        //            }
        //            else
        //            {
        //                rm.SetResponse(false, "Usuario o Password Incorrecto");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return rm;
        //}
    }
}

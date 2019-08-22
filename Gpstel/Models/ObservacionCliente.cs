namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("ObservacionCliente")]
    public partial class ObservacionCliente
    {
        [Key]
        public int idobservacion { get; set; }

        [StringLength(100)]
        public string observacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int? idcliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public List<ObservacionCliente> listarObservaciones(int id)
        {
            var observaciones = new List<ObservacionCliente>();

            try
            {
                using (var context = new ModelGps())
                {
                    observaciones = context.ObservacionCliente
                        .Include("Cliente")
                        .Where(x => x.idcliente == id)
                        .ToList();

                }
            }
            catch (Exception)
            {

                using (var context = new ModelGps())
                {
                    observaciones = context.ObservacionCliente
                        .Include("Cliente")
                        .Where(x => x.idcliente == id)
                        .ToList();

                }
            }
            return observaciones;
        }

        public string guardarEditar()
        {

            string respuesta = "";
            try
            {
                using (var context = new ModelGps())
                {

                    if (this.idobservacion == 0)
                    {
                        context.Entry(this).State = EntityState.Added;
                        respuesta = "ingresado";
                    }
                    else
                    {
                        context.Entry(this).State = EntityState.Modified;
                        respuesta = "modificado";
                    }

                    context.SaveChanges();

                }
            }
            catch (Exception e)
            // Andrei Estuvo aquí 
            //jajaja

            {

                throw;
            }
            return respuesta;
        }
    }
}

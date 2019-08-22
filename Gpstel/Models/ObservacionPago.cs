namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("ObservacionPago")]
    public partial class ObservacionPago
    {
        [Key]
        public int idobservacio { get; set; }

        [StringLength(100)]
        public string observacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int? idpago { get; set; }

        public virtual Pago Pago { get; set; }
        public List<ObservacionPago> listarObservaciones(int id)
        {
            var observaciones = new List<ObservacionPago>();

            try
            {
                using (var context = new ModelGps())
                {
                    observaciones = context.ObservacionPago
                        .Include("Pago")
                        .Where(x => x.idpago == id)
                        .ToList();

                }
            }
            catch (Exception)
            {

                using (var context = new ModelGps())
                {
                    observaciones = context.ObservacionPago
                        .Include("Pago")
                        .Where(x => x.idpago == id)
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

                    if (this.idobservacio == 0)
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

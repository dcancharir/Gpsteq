namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("ObservacionVehiculo")]
    public partial class ObservacionVehiculo
    {
        [Key]
        public int idobservacion { get; set; }

        [StringLength(100)]
        public string observacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int? idvehiculo { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
        public List<ObservacionVehiculo> listarObservaciones(int id)
        {
            var observaciones = new List<ObservacionVehiculo>();

            try
            {
                using (var context = new ModelGps())
                {
                    observaciones = context.ObservacionVehiculo
                        .Include("Vehiculo")
                        .Where(x => x.idvehiculo == id)
                        .ToList();

                }
            }
            catch (Exception)
            {

                using (var context = new ModelGps())
                {
                    observaciones = context.ObservacionVehiculo
                        .Include("Vehiculo")
                        .Where(x => x.idvehiculo == id)
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

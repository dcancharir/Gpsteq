namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Pago")]
    public partial class Pago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pago()
        {
            ObservacionPago = new HashSet<ObservacionPago>();
        }

        [Key]
        public int idpago { get; set; }

        [StringLength(50)]
        public string concepto { get; set; }

        public DateTime? fecha_pago { get; set; }

        public int? idvehiculo { get; set; }

        public decimal? monto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObservacionPago> ObservacionPago { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }

        public List<Pago> listarPagos()
        {
            var pagos = new List<Pago>();

            try
            {
                using (var context = new ModelGps())
                {

                    pagos = context.Pago.Include("Vehiculo")
                        .ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            return pagos;
        }
        public List<Pago> listarPagosxVehiculo(int id)
        {
            var pagos = new List<Pago>();

            try
            {
                using (var context = new ModelGps())
                {

                    pagos = context.Pago.Include("Vehiculo").Where(x => x.idvehiculo == id).OrderByDescending(x=>x.fecha_pago)
                        .ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            return pagos;
        }
        public Pago obtenerPago(int id)
        {
            var objPago = new Pago();

            try
            {
                using (var context = new ModelGps())
                {

                    objPago = context.Pago
                        .Include("Vehiculo")
                        .Where(x => x.idpago == id)
                        .Single();

                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return objPago;

        }
        //public List<Pago> Buscar(string criterio)
        //{
        //    var clientes = new List<Vehiculo>();
        //    try
        //    {
        //        using (var db = new ModelGps())
        //        {
        //            clientes = db.Vehiculo.Where(x => x.Cliente.Equals(criterio) || x.particular_mtc.Equals(criterio)).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return clientes;
        //}
        public void guardar()
        {
            try
            {
                using (var db = new ModelGps())
                {
                    if (this.idpago > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

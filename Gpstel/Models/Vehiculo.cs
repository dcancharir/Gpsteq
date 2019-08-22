namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Vehiculo")]
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            ObservacionVehiculo = new HashSet<ObservacionVehiculo>();
            Pago = new HashSet<Pago>();
        }

        [Key]
        public int idvehiculo { get; set; }

        [StringLength(7)]
        public string placa { get; set; }

        [StringLength(20)]
        public string marca { get; set; }

        [StringLength(20)]
        public string modelo { get; set; }

        [StringLength(4)]
        public string anio_vehiculo { get; set; }

        [StringLength(20)]
        public string color { get; set; }

        [StringLength(20)]
        public string nro_motor { get; set; }

        [StringLength(10)]
        public string particular_mtc { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int? idgps { get; set; }

        public DateTime? fecha_instalacion { get; set; }

        public int? idcliente { get; set; }

        public decimal? mensualidad { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual GPS GPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObservacionVehiculo> ObservacionVehiculo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }

        public void guardarEditar()
        {


            try
            {
                using (var context = new ModelGps())
                {
                    if (this.idvehiculo == 0)
                    {
                        context.Entry(this).State = EntityState.Added;
                    }
                    else
                    {
                        context.Entry(this).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<Vehiculo> listarVehiculo()
        {
            var listarVehiculo = new List<Vehiculo>();
            //var listarClientes = new List<Cliente>();

            try
            {
                using (var context = new ModelGps())
                {

                    listarVehiculo = context.Vehiculo
                        .Include("Cliente")
                        .Include("GPS")
                        .ToList();


                    //  listarClientes = context.Cliente.GroupJoin(context.Distrito, cli => cli.iddistrito,
                    //     dis => dis.iddistrito, (cli, dis) => new { cli, dis }).ToList();



                    //   listarCliente = context.Database.SqlQuery<Cliente>("select * from Cliente cli inner join Distrito di on cli.iddistrito = di.iddistrito inner join Provincia p on di.idprovincia = p.idprovincia inner join Departamento de on p.iddepartamento= de.iddepartamento")
                    // .ToList();

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            return listarVehiculo;
        }
        public Vehiculo obtenerVehiculoxId(int id)
        {

            var objVehiculo = new Vehiculo();

            try
            {
                using (var context = new ModelGps())
                {
                    objVehiculo = context.Vehiculo
                        .Include("Cliente")
                        .Include("GPS")
                        .Where(x => x.idvehiculo == id)
                        .Single();
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return objVehiculo;

        }


      

        


        //public Vehiculo obtenerVehiculo(int id)
        //{

        //    var objVehiculo = new Vehiculo();

        //    try
        //    {
        //        using (var context = new ModelGps())
        //        {
        //            objVehiculo = context.Vehiculo
        //                .Include("Cliente")
        //                .Include("GPS")
        //                .Where(x => x.idcliente == id)
        //                .Single();
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }
        //    return objVehiculo;

        //}

        public void eliminarVehiculo()
        {

            try
            {
                using (var context = new ModelGps())
                {
                    context.Entry(this).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<GPS> obtenerGpsNoRepetido()
        {

            var noRepetido = new List<GPS>();
            try
            {

                using (var context = new ModelGps())
                {



                    //  noRepetido = context.CHIP.SqlQuery("Select * from CHIP where not exists (select null from GPS where GPS.idchip = CHIP.idchip)")
                    //    .ToList();


                    noRepetido = context.Database.SqlQuery<GPS>("Select * from GPS where not exists (select null from Vehiculo where Vehiculo.idgps = GPS.idgps)")
                   .ToList();


                }
            }
            catch (Exception)
            {

                throw;
            }
            return noRepetido;
        }
    }
}

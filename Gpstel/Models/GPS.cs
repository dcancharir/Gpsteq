namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    public partial class GPS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GPS()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public int idgps { get; set; }

        [StringLength(50)]
        public string modelo { get; set; }

        [StringLength(20)]
        public string estado_uso { get; set; }

        [StringLength(20)]
        public string garantia { get; set; }

        public int idchip { get; set; }

        public DateTime? fecha_compra { get; set; }

        [StringLength(50)]
        public string imei { get; set; }

        public virtual CHIP CHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }

        public void guardarEditar()
        {

            try
            {
                using (var context = new ModelGps())
                {
                    if (this.idgps == 0)
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

        public List<GPS> listarGps()
        {
            var listarGps = new List<GPS>();

            try
            {
                using (var context = new ModelGps())
                {

                    listarGps = context.GPS
                        .Include("CHIP")
                        .ToList();

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            return listarGps;
        }


        public GPS obtenerGps(int id)
        {

            var objGps = new GPS();

            try
            {
                using (var context = new ModelGps())
                {
                    objGps = context.GPS
                        .Include("Vehiculo")
                        .Include("CHIP")
                        .Where(x => x.idgps == id)
                        .Single();
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return objGps;

        }

        public void eliminarGps()
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

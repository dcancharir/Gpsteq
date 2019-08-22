namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("CHIP")]
    public partial class CHIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHIP()
        {
            GPS = new HashSet<GPS>();
        }

        [Key]
        public int idchip { get; set; }

        [StringLength(50)]
        public string operador { get; set; }

        [StringLength(20)]
        public string tipo_contrato { get; set; }

        [StringLength(18)]
        public string numero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GPS> GPS { get; set; }
        public void guardarEditar()
        {

            try
            {
                using (var context = new ModelGps())
                {
                    if (this.idchip == 0)
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

        public List<CHIP> listarchip()
        {

            var listaChips = new List<CHIP>();

            try
            {
                using (var context = new ModelGps())
                {
                    listaChips = context.CHIP.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return listaChips;
        }

        public CHIP obtenerChip(int id)
        {
            var objChip = new CHIP();

            try
            {
                using (var context = new ModelGps())
                {

                    objChip = context.CHIP
                        .Include("GPS")
                        .Where(x => x.idchip == id)
                        .Single();

                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return objChip;

        }

        public void eliminarChip()
        {

            try
            {
                using (var context = new ModelGps())
                {
                    context.Entry(this).State = EntityState.Deleted;


                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<CHIP> obtenerChipnoRepetido()
        {

            var noRepetido = new List<CHIP>();
            try
            {

                using (var context = new ModelGps())
                {



                    //  noRepetido = context.CHIP.SqlQuery("Select * from CHIP where not exists (select null from GPS where GPS.idchip = CHIP.idchip)")
                    //    .ToList();


                    noRepetido = context.Database.SqlQuery<CHIP>("Select * from CHIP where not exists (select null from GPS where GPS.idchip = CHIP.idchip)")
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

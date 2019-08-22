namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Provincia")]
    public partial class Provincia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provincia()
        {
            Distrito = new HashSet<Distrito>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idprovincia { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        public int? iddepartamento { get; set; }

        public virtual Departamento Departamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Distrito> Distrito { get; set; }
        public List<Provincia> ProvinciDepartamento(int id)
        {

            var resultadoProvincias = new List<Provincia>();

            try
            {
                using (var context = new ModelGps())
                {
                    resultadoProvincias = context.Provincia.Include("Departamento").Include("Distrito")
                        .Where(x => x.iddepartamento == id).ToList();


                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultadoProvincias;
        }
    }

}

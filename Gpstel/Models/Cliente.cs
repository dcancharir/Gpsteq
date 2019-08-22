namespace Gpstel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            ObservacionCliente = new HashSet<ObservacionCliente>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public int idcliente { get; set; }

        public DateTime? fecha_contrato { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string apellido { get; set; }

        [StringLength(11)]
        //[RegularExpression ("/ (^ ([0 - 9]{8, 11})|^)$/",ErrorMessage ="Formato Incorrecto")]
        public string dni_ruc { get; set; }

        [StringLength(9)]
        //[RegularExpression(@"/(^([0-9]{6,9})|^)$/", ErrorMessage = "Formato Incorrecto")]
        public string telefono { get; set; }

        [StringLength(9)]
        //[RegularExpression(@"/(^([0-9]{9,9})|^)$/", ErrorMessage = "Formato Incorrecto")]
        public string celular { get; set; }

        [StringLength(50)]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string correo { get; set; }

        [StringLength(250)]
        public string direccion { get; set; }

        public int? iddistrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObservacionCliente> ObservacionCliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }

        public virtual Distrito Distrito { get; set; }
        public void guardarEditar()
        {


            try
            {
                using (var context = new ModelGps())
                {
                    if (this.idcliente == 0)
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

        public List<Cliente> listarCliente()
        {
            var listarCliente = new List<Cliente>();
            var listarClientes = new List<Cliente>();

            try
            {
                using (var context = new ModelGps())
                {

                    listarCliente = context.Cliente.Include("Distrito").ToList();


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


            return listarCliente;
        }


        public Cliente obtenerCliente(int id)
        {

            var objCliente = new Cliente();

            try
            {
                using (var context = new ModelGps())
                {
                    objCliente = context.Cliente
                        .Include("Distrito")
                        .Where(x => x.idcliente == id)
                        .Single();
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return objCliente;

        }

        public void eliminarCliente()
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
    }
}

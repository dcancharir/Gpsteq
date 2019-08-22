namespace Gpstel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelGps : DbContext
    {
        public ModelGps()
            : base("name=ModelGps")
        {
        }

        public virtual DbSet<CHIP> CHIP { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<GPS> GPS { get; set; }
        public virtual DbSet<ObservacionCliente> ObservacionCliente { get; set; }
        public virtual DbSet<ObservacionPago> ObservacionPago { get; set; }
        public virtual DbSet<ObservacionVehiculo> ObservacionVehiculo { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHIP>()
                .Property(e => e.operador)
                .IsUnicode(false);

            modelBuilder.Entity<CHIP>()
                .Property(e => e.tipo_contrato)
                .IsUnicode(false);

            modelBuilder.Entity<CHIP>()
                .Property(e => e.numero)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHIP>()
                .HasMany(e => e.GPS)
                .WithRequired(e => e.CHIP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.dni_ruc)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Distrito>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<GPS>()
                .Property(e => e.modelo)
                .IsUnicode(false);

            modelBuilder.Entity<GPS>()
                .Property(e => e.estado_uso)
                .IsUnicode(false);

            modelBuilder.Entity<GPS>()
                .Property(e => e.garantia)
                .IsUnicode(false);

            modelBuilder.Entity<GPS>()
                .Property(e => e.imei)
                .IsUnicode(false);

            modelBuilder.Entity<ObservacionCliente>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<ObservacionCliente>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ObservacionPago>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<ObservacionPago>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ObservacionVehiculo>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<ObservacionVehiculo>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pago>()
                .Property(e => e.concepto)
                .IsUnicode(false);

            modelBuilder.Entity<Pago>()
                .Property(e => e.monto)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Pago>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provincia>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.placa)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.marca)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.anio_vehiculo)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.nro_motor)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.particular_mtc)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.mensualidad)
                .HasPrecision(10, 2);
        }
    }
}

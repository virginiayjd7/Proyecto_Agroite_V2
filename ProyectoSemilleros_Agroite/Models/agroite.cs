using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProyectoSemilleros_Agroite.Models
{
    public partial class agroite : DbContext
    {
        public agroite()
            : base("name=agroite")
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Finca> Finca { get; set; }
        public virtual DbSet<Frecuencia> Frecuencia { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UnidadExtension> UnidadExtension { get; set; }
        public virtual DbSet<UnidadVolumen> UnidadVolumen { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Departamento)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Via_Acceso)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Fuente_Agua)
                .IsUnicode(false);

            modelBuilder.Entity<Finca>()
                .Property(e => e.Almacen_Agua)
                .IsUnicode(false);

            modelBuilder.Entity<Frecuencia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio_Referencial)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Fecha_Inicio)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Fecha_Fin)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Cantidad_Producida)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadExtension>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadVolumen>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadVolumen>()
                .HasMany(e => e.Producto)
                .WithOptional(e => e.UnidadVolumen)
                .HasForeignKey(e => e.IdUnidad_Volumen);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Num_Identificacion)
                .IsFixedLength();

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Organizacion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }
    }
}

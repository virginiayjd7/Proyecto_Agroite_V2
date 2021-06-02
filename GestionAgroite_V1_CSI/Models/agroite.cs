using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GestionAgroite_V1_CSI.Models
{
    public partial class agroite : DbContext
    {
        public agroite()
            : base("name=agroite")
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Agricultor> Agricultor { get; set; }
        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Asociacion> Asociacion { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<Frecuencia> Frecuencia { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Transportador> Transportador { get; set; }
        public virtual DbSet<UnidadVolumen> UnidadVolumen { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Num_Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Foto_Perfil)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Agricultor>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Localidad)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Capacidad)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Precio)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Cantida_Dejada)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.Unidad_Medida)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Ruc)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Razon_Social)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Dapartamento)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Asociacion>()
                .Property(e => e.Representante)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Compra>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Compra>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DetalleCompra>()
                .Property(e => e.Cantidad)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DetalleCompra>()
                .Property(e => e.Precio_Unitario)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DetalleCompra>()
                .Property(e => e.Subtotal)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.Cantidad)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.Subtotal)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DetalleVenta>()
                .Property(e => e.Cantidad)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DetalleVenta>()
                .Property(e => e.Subtotal)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.Fecha_Envio)
                .IsUnicode(false);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.Fechar_Entrega)
                .IsUnicode(false);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.Detalles)
                .IsUnicode(false);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.Fecha_Pedido)
                .IsUnicode(false);

            modelBuilder.Entity<Frecuencia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Pago>()
                .Property(e => e.Num_Transaccion)
                .IsUnicode(false);

            modelBuilder.Entity<Pago>()
                .Property(e => e.Cantidad)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Pago>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.Total)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.IGV)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio_Referencial)
                .HasPrecision(16, 2);

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
                .HasPrecision(16, 2);

            modelBuilder.Entity<Transportador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Transportador>()
                .Property(e => e.Tefono)
                .IsUnicode(false);

            modelBuilder.Entity<Transportador>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadVolumen>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Num_Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Razon_Social)
                .IsUnicode(false);

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
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Año)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Capacidad)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Precio)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Unidad_Medida)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Tipo_Carga)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Carga_Total)
                .IsFixedLength();

            modelBuilder.Entity<Venta>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.Total)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Venta>()
                .Property(e => e.IGV)
                .HasPrecision(16, 2);
        }
    }
}

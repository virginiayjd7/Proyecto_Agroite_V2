namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Almacen = new HashSet<Almacen>();
            DetalleCompra = new HashSet<DetalleCompra>();
            DetallePedido = new HashSet<DetallePedido>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int IdProducto { get; set; }

        public int? IdCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre_Producto { get; set; }

        public decimal Precio_Referencial { get; set; }

        [Required]
        public byte[] Imagenes_Producto { get; set; }

        [StringLength(200)]
        public string Descripcion_Producto { get; set; }

        [StringLength(50)]
        public string Fecha_Inicio { get; set; }

        [StringLength(50)]
        public string Fecha_Fin { get; set; }

        public decimal? Cantidad_Producida { get; set; }

        public int? IdUnidadVolumen { get; set; }

        public int? IdFrecuencia { get; set; }

        public int? IdAsociacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Almacen> Almacen { get; set; }

        public virtual Asociacion Asociacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

        public virtual Frecuencia Frecuencia { get; set; }

        public virtual UnidadVolumen UnidadVolumen { get; set; }
    }
}

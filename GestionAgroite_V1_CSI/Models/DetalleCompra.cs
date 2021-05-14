namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleCompra")]
    public partial class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        public int? IdProducto { get; set; }

        public int? IdCompra { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Precio_Unitario { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual Compra Compra { get; set; }

        public virtual Producto Producto { get; set; }
    }
}

namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallePedido")]
    public partial class DetallePedido
    {
        [Key]
        public int IdDetallePedido { get; set; }

        public int? IdPedido { get; set; }

        public int? IdProducto { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
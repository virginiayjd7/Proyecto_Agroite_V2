namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venta")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
            Entrega = new HashSet<Entrega>();
        }

        [Key]
        public int IdVenta { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public int? Num_Serie { get; set; }

        public int? IdPedido { get; set; }

        public decimal? Total { get; set; }

        public decimal? IGV { get; set; }

        public int? IdTransportador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entrega { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Transportador Transportador { get; set; }
    }
}

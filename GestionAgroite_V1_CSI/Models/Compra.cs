namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compra")]
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
        }

        [Key]
        public int IdCompra { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public decimal? Total { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdTransportador { get; set; }

        public virtual Transportador Transportador { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }
}

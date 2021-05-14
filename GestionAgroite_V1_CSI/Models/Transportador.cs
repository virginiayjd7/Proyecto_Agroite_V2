namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transportador")]
    public partial class Transportador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transportador()
        {
            Compra = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int IdTransportador { get; set; }

        public int? IdVehiculo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Tefono { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int? Disponibilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}

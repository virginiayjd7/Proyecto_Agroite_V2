namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculos()
        {
            Transportador = new HashSet<Transportador>();
        }

        [Key]
        public int IdVehiculo { get; set; }

        [StringLength(20)]
        public string Marca { get; set; }

        [StringLength(20)]
        public string Modelo { get; set; }

        [StringLength(20)]
        public string Año { get; set; }

        [StringLength(20)]
        public string Tipo { get; set; }

        [StringLength(20)]
        public string Placa { get; set; }

        public int? Capacidad { get; set; }

        public int? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportador> Transportador { get; set; }
    }
}

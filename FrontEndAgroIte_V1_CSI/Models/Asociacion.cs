namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asociacion")]
    public partial class Asociacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asociacion()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int IdAsociacion { get; set; }

        [StringLength(15)]
        public string Ruc { get; set; }

        [StringLength(150)]
        public string Razon_Social { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Dapartamento { get; set; }

        [StringLength(50)]
        public string Provincia { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

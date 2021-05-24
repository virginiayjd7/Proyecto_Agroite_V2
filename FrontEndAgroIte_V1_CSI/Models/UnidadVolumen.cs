namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class UnidadVolumen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadVolumen()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IdUnidadVolumen { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<UnidadVolumen> Listar()
        {
            var unidadvolumen = new List<UnidadVolumen>();

            try
            {
                using (var db = new agroite())
                {

                    unidadvolumen = db.UnidadVolumen.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadvolumen;
        }
    }
}

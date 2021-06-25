namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Actividad")]
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int IdActividad { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
        public List<Actividad> Listar()
        {
            var actividad = new List<Actividad>();

            try
            {
                using (var db = new agroite())
                {

                    actividad = db.Actividad.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividad;
        }
    }
}
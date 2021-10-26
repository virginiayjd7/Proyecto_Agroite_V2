namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Frecuencia")]
    public partial class Frecuencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Frecuencia()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IdFrecuencia { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<Frecuencia> Listar()
        {
            var frecuencia = new List<Frecuencia>();
            try
            {
                using (var db = new agroite())
                {
                    frecuencia = db.Frecuencia.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return frecuencia;
        }
        public Frecuencia Obtener(int id)
        {
            var frecuencia = new Frecuencia();
            try
            {
                using (var db = new agroite())
                {

                    frecuencia = db.Frecuencia
                                    .Where(x => x.IdFrecuencia == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return frecuencia;

        }
        public List<Frecuencia> Buscar(string criterio)
        {
            var frecuencia = new List<Frecuencia>();

            try
            {
                using (var db = new agroite())
                {
                    frecuencia = db.Frecuencia
                        .Where(x => x.Nombre.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return frecuencia;
        }

    }
}
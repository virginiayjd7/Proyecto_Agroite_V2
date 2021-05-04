namespace ProyectoSemilleros_Agroite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("UnidadExtension")]
    public partial class UnidadExtension
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadExtension()
        {
            Finca = new HashSet<Finca>();
        }

        [Key]
        public int IdUnidadExtension { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finca> Finca { get; set; }
        public List<UnidadExtension> Listar()
        {
            var unidadextension = new List<UnidadExtension>();

            try
            {
                using (var db = new agroite())
                {

                    unidadextension = db.UnidadExtension.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadextension;
        }

        public UnidadExtension Obtener(int id)
        {
            var unidadextension = new UnidadExtension();
            try
            {
                using (var db = new agroite())
                {

                    unidadextension = db.UnidadExtension
                                    .Where(x => x.IdUnidadExtension == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadextension;
        }
        public List<UnidadExtension> Buscar(string criterio)
        {
            var unidadextension = new List<UnidadExtension>();

            try
            {
                using (var db = new agroite())
                {
                    unidadextension = db.UnidadExtension
                        .Where(x => x.Nombre.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return unidadextension;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdUnidadExtension > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                using (var db = new agroite())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
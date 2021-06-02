namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Asociacion")]
    public partial class Asociacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asociacion()
        {
            Producto = new HashSet<Producto>();
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

        public int? IdAgricultor { get; set; }

        [StringLength(9)]
        public string Telefono { get; set; }

        [StringLength(150)]
        public string Representante { get; set; }

        public int? Integrantes { get; set; }

        public virtual Agricultor Agricultor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<Asociacion> Listar()
        {
            var asociacion = new List<Asociacion>();

            try
            {
                using (var db = new agroite())
                {

                    asociacion = db.Asociacion.Include("Agricultor").ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return asociacion;
        }

        public Asociacion Obtener(int id)
        {
            var asociacion = new Asociacion();
            try
            {
                using (var db = new agroite())
                {

                    asociacion = db.Asociacion
                                    .Where(x => x.IdAsociacion == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return asociacion;
        }
        public List<Asociacion> Buscar(string criterio)
        {
            var asociacion = new List<Asociacion>();

            try
            {
                using (var db = new agroite())
                {
                    asociacion = db.Asociacion
                        .Where(x => x.Razon_Social.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return asociacion;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdAsociacion > 0)
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
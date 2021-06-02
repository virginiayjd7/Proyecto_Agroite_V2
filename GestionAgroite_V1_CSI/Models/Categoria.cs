namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IdCategoria { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<Categoria> Listar()
        {
            var categoria = new List<Categoria>();

            try
            {
                using (var db = new agroite())
                {

                    categoria = db.Categoria.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }
        public List<Categoria> Buscar(string criterio)
        {
            var categoria = new List<Categoria>();

            try
            {
                using (var db = new agroite())
                {

                    categoria = db.Categoria
                        .Where(x => x.Nombre.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }
        public Categoria Obtener(int id)
        {
            var categoria = new Categoria();
            try
            {
                using (var db = new agroite())
                {

                    categoria = db.Categoria
                                      .Where(x => x.IdCategoria == id)
                                      .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;

        }
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {

                    if (this.IdCategoria > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else//no existe
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
        public List<Categoria> ObtenerUsuarioPorProducto()//retorna una lista o coleccion de objetos
        {
            var categoria = new List<Categoria>();
            try
            {
                using (var db = new agroite())
                {
                    categoria = db.Categoria.Include("Producto").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return categoria;
        }

    }
}
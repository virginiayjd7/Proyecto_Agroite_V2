namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Almacen")]
    public partial class Almacen
    {
        [Key]
        public int IdAlmacen { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Localidad { get; set; }

        [StringLength(50)]
        public string Provincia { get; set; }

        public decimal? Capacidad { get; set; }

        public int? IdProducto { get; set; }

        public decimal? Precio { get; set; }

        public DateTime? Tiempo_Inicio { get; set; }

        public DateTime? Tiempo_Final { get; set; }

        public decimal? Cantida_Dejada { get; set; }

        [StringLength(50)]
        public string Unidad_Medida { get; set; }

        public virtual Producto Producto { get; set; }

        public List<Almacen> Listar()
        {
            var almacen = new List<Almacen>();

            try
            {
                using (var db = new agroite())
                {

                    almacen = db.Almacen.Include("Producto").ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return almacen;
        }

        public Almacen Obtener(int id)
        {
            var almacen = new Almacen();
            try
            {
                using (var db = new agroite())
                {

                    almacen = db.Almacen.Include("Producto").Where(x => x.IdProducto == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return almacen;
        }
        public List<Almacen> Buscar(string criterio)
        {
            var asociacion = new List<Almacen>();

            try
            {
                using (var db = new agroite())
                {
                    asociacion = db.Almacen
                        .Where(x => x.Nombre.Contains(criterio)).ToList();
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
                    if (this.IdAlmacen > 0)
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

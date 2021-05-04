namespace ProyectoSemilleros_Agroite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web;

    [Table("Finca")]
    public partial class Finca
    {
        [Key]
        public int IdFinca { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }

        [StringLength(100)]
        public string Departamento { get; set; }

        [StringLength(100)]
        public string Municipio { get; set; }

        [StringLength(100)]
        public string Via_Acceso { get; set; }

        [StringLength(100)]
        public string Fuente_Agua { get; set; }

        [StringLength(50)]
        public string Almacen_Agua { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdUnidadExtension { get; set; }

        public virtual UnidadExtension UnidadExtension { get; set; }

        public virtual Usuario Usuario { get; set; }
        public List<Finca> Listar()
        {
            var finca = new List<Finca>();
            try
            {
                using (var db = new agroite())
                {
                    finca = db.Finca.Include("Usuario").Include("UnidadExtension").ToList();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return finca;
        }
        public List<Finca> Buscar(int id)
        {
            var finca = new List<Finca>();
            try
            {
                using (var db = new agroite())
                {
                    finca = db.Finca.Include("Usuario").Include("UnidadExtension").Where(x => x.IdUsuario == id).ToList();
                   
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return finca;
        }
        public List<Finca> Buscar2(string criterio)
        {
            var finca = new List<Finca>();

            try
            {
                using (var db = new agroite())
                {

                    finca = db.Finca
                       .Where(x => x.Nombre.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return finca;
        }
        public List<Finca> Listar1()//
        {
            var finca = new List<Finca>();

            try
            {
                using (var db = new agroite())
                {
                    finca = db.Finca.Include("UnidadExtension").ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return finca;
        }
        public Finca Obtener(int id)
        {
            var finca= new Finca();
            try
            {
                using (var db = new agroite())
                {
                    finca = db.Finca.Include("Usuario").Include("UnidadExtension").Where(x => x.IdFinca == id)
                                      .SingleOrDefault();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return finca;
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
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdFinca > 0)
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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}


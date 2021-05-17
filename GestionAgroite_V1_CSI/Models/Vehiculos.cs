namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        public decimal? Capacidad { get; set; }

        public int? Estado { get; set; }

        public decimal? Precio { get; set; }

        [StringLength(100)]
        public string Unidad_Medida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportador> Transportador { get; set; }

        public List<Vehiculos> Listar()
        {
            var vehiculos = new List<Vehiculos>();
            try
            {
                using (var db = new agroite())
                {
                    vehiculos = db.Vehiculos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vehiculos;
        }
        public Vehiculos Obtener(int id)
        {
            var vehiculo = new Vehiculos();
            try
            {
                using (var db = new agroite())
                {
                    vehiculo = db.Vehiculos.Where(x => x.IdVehiculo == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculo;
        }

        public List<Vehiculos> Buscar(string criterio)
        {
            var vehiculo = new List<Vehiculos>();
            try
            {
                using (var db = new agroite())
                {
                    vehiculo = db.Vehiculos.Where(x => x.Marca.Contains(criterio) || x.Modelo.Contains(criterio) || x.Tipo.Contains(criterio) || x.Placa.Contains(criterio) || x.Año.Contains(criterio)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vehiculo;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdVehiculo > 0)
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
    }
}

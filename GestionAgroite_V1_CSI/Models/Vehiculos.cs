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

        [StringLength(50)]
        public string Tipo_Carga { get; set; }

        [StringLength(10)]
        public string Carga_Total { get; set; }

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
                    db.Configuration.ProxyCreationEnabled = false;
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
        public List<Vehiculos> BuscarTipoCarga(string criterio)
        {
            bool espacios = criterio.Contains(' ');
            if (espacios)
            {
                string[] datos = criterio.Split(' ');
                string pri = datos[0];
                criterio = pri;
            }
            var vehiculo = new List<Vehiculos>();
            try
            {
                using (var db = new agroite())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    vehiculo = db.Vehiculos.Include("Transportador").Where(x => x.Tipo_Carga.ToLower().Contains(criterio.ToLower())).ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vehiculo;
        }
        public List<Vehiculos> listarVehiculos()
        {

            var vehiculo = new List<Vehiculos>();
            try
            {
                using (var db = new agroite())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    vehiculo = db.Vehiculos.Include("Transportador").ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vehiculo;
        }
        public List<Transportador> BuscarTipoCarga2(string criterio)
        {
            bool espacios = criterio.Contains(' ');
            if (espacios)
            {
                string[] datos = criterio.Split(' ');
                string pri = datos[0];
                criterio = pri;
            }
            var vehiculo = new List<Transportador>();
            try
            {
                using (var db = new agroite())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    var query = (from de in db.Transportador
                                 join pro in db.Vehiculos on de.IdVehiculo equals pro.IdVehiculo
                                 where pro.Tipo_Carga.Contains(criterio)
                                 select new
                                 {
                                     de.IdTransportador,
                                     de.Nombre,
                                     pro.Marca,
                                     pro.IdVehiculo,
                                     pro.Capacidad,
                                     pro.Precio,
                                     pro.Carga_Total
                                 }).ToList();

                    foreach (var item in query)
                    {
                        Vehiculos a = new Vehiculos();
                        a.Marca = item.Marca;
                        a.IdVehiculo = item.IdVehiculo;
                        a.Precio = item.Precio;
                        a.Carga_Total = item.Carga_Total;
                        a.Capacidad = item.Capacidad;
                        vehiculo.Add(new Transportador()
                        {
                            Vehiculos = a,
                            IdTransportador = item.IdTransportador,
                            Nombre = item.Nombre

                        });

                    }
                    //   vehiculo = db.Transportador.Include("Vehiculos").Where(x => x.Vehiculos.Tipo_Carga.ToLower().Contains(criterio.ToLower())).ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vehiculo;
        }
        public List<Transportador> ListarTRas()
        {
            var trasnpoador = new List<Transportador>();
            try
            {
                using (var db = new agroite())
                {
                    trasnpoador = db.Transportador.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return trasnpoador;
        }
    }
}
